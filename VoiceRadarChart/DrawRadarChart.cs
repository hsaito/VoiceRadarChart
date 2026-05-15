using ScottPlot;

class RadarChart
{
    public static void DrawRadarChart(Plot plt, string[] labels, double[] values)
    {
        int count = labels.Length;
        double angleStep = 2 * Math.PI / count;

        // 正規化（F1〜F5 は Hz なのでそのままだとスケールが合わない）
        double max = values.Max();
        double[] norm = values.Select(v => v / max).ToArray();

        // 軸線とラベル
        for (int i = 0; i < count; i++)
        {
            double angle = i * angleStep;
            double x = Math.Cos(angle);
            double y = Math.Sin(angle);

            plt.Add.Line(0, 0, x, y);
            plt.Add.Text(labels[i], x * 1.15, y * 1.15);
        }

        // データ点
        double[] xs = new double[count + 1];
        double[] ys = new double[count + 1];

        for (int i = 0; i < count; i++)
        {
            double angle = i * angleStep;
            xs[i] = Math.Cos(angle) * norm[i];
            ys[i] = Math.Sin(angle) * norm[i];
        }

        xs[count] = xs[0];
        ys[count] = ys[0];

        plt.Add.Polygon(xs, ys);

        plt.Axes.SetLimits(-1.3, 1.3, -1.3, 1.3);
        plt.HideGrid();
    }
}