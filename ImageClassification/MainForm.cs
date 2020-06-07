using System;
using System.IO;
using System.Drawing;
using System.Windows.Forms;
using TensorFlow;
using Emgu.CV;
using Emgu.CV.CvEnum;


namespace ImageClassification
{
    public partial class MainForm : Form
    {
        static string modelFile = "tensorflow_inception_graph.pb";
        static string labelsFile = "imagenet_comp_graph_label_strings.txt";
        static string[] labels = File.ReadAllLines(labelsFile);
        public MainForm()
        {
            InitializeComponent();
        }
        private void buttonRun_Click(object sender, EventArgs e)
        {
            TFGraph graph = new TFGraph();
            // 恢复模型
            byte[] model = File.ReadAllBytes(modelFile);
            graph.Import(model, "");
            using (TFSession session = new TFSession(graph))
            {
                // 浏览文件并选择待识别的图片
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.InitialDirectory = "C:\\";
                openFileDialog.Filter = "图片|*.jpg";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    DateTime TimeStart = DateTime.Now;

                    // 读取图片并显示
                    string file = openFileDialog.FileName;
                    Mat img = CvInvoke.Imread(file, LoadImageType.AnyColor);
                    Mat dst = new Mat();
                    CvInvoke.Resize(img, dst, new Size(imageBox.Width, imageBox.Height));
                    imageBox.Image = dst;

                    // 将图片转换为标准化的Tensor作为网络输入
                    TFTensor tensor = CreateTensorFromImageFile(file);

                    // 前向推理
                    TFSession.Runner runner = session.GetRunner();
                    runner.AddInput(graph["input"][0], tensor);
                    runner.Fetch(graph["output"][0]);
                    TFTensor[] predictions = runner.Run();
                    TFTensor prediction = predictions[0];

                    int labelIdx = 0;
                    float probability = 0;

                    // 解析结果（两种方式）
                    bool jagged = true;
                    if (jagged)
                    {
                        float[] probabilities = ((float[][])prediction.GetValue(jagged: true))[0];
                        for (int i = 0; i < probabilities.Length; i++)
                        {
                            if (probabilities[i] > probability)
                            {
                                labelIdx = i;
                                probability = probabilities[i];
                            }
                        }

                    }
                    else
                    {
                        float[,] probabilities = (float[,])prediction.GetValue(jagged: false);
                        for (int i = 0; i < probabilities.GetLength(1); i++)
                        {
                            if (probabilities[0, i] > probability)
                            {
                                labelIdx = i;
                                probability = probabilities[0, i];
                            }
                        }
                    }

                    // 显示结果
                    textName.Text = labels[labelIdx];
                    textProb.Text = (probability * 100.0).ToString("0.00") + "%";
                    TimeSpan TimeCount = DateTime.Now - TimeStart;
                    textTime.Text = TimeCount.TotalMilliseconds.ToString("0") + "ms";
                }
            }
        }

        // 将图片转换为适配模型输入尺寸的Tensor
        static TFTensor CreateTensorFromImageFile(string file)
        {
            // 将图片读取为Tensor
            byte[] contents = File.ReadAllBytes(file);
            TFTensor tensor = TFTensor.CreateString(contents);

            // 创建一个图对Tensor进行标准化处理
            const int W = 224;
            const int H = 224;
            const float Mean = 117;
            const float Scale = 1;

            TFGraph graph = new TFGraph();
            TFOutput input, output;
            input = graph.Placeholder(TFDataType.String);

            output = graph.DecodeJpeg(contents: input, channels: 3);
            output = graph.Cast(output, DstT: TFDataType.Float);
            output = graph.ExpandDims(output, graph.Const(0, "make_batch"));
            output = graph.ResizeBilinear(output, graph.Const(new int[] { W, H }, "size"));
            output = graph.Sub(output, graph.Const(Mean, "mean"));
            output = graph.Div(output, graph.Const(Scale, "scale"));

            // 执行图
            using (var session = new TFSession(graph))
            {
                var normalized = session.Run(
                         inputs: new[] { input },
                         inputValues: new[] { tensor },
                         outputs: new[] { output });

                return normalized[0];
            }
        }
    }
}