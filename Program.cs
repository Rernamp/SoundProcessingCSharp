

public class Program {
    public static void Main(string[] args) {
        // create a plot
        ScottPlot.Plot myPlot = new();
        myPlot.Add.Signal(ScottPlot.Generate.Sin());
        myPlot.Add.Signal(ScottPlot.Generate.Cos());

        // launch the plot in an interactive plot window
        ScottPlot.WinForms.FormsPlotViewer.Launch(myPlot);
        ScottPlot.WinForms.FormsPlotViewer.Launch(myPlot, "12");
    }
}