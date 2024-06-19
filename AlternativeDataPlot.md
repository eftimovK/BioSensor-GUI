## Alternative data plot, without using DataStreamer

### Declare class attributes (and define in the constructor?)
```
        private List<int> dataListY = new();
        private List<int> dataListX = new();
```
### Implement update function

```
        private void UpdatePlot(string data)
        {
            data = data.TrimEnd('\r', '\n');

            int newValue;
            bool res = Int32.TryParse(data, out newValue);

            if (res)
            {
                dataListY.Add(newValue);
                dataListY = dataListY.TakeLast(dataPointsMax).ToList();

                // plot data                
                dataPlot.Plot.Clear();
                dataPlot.Plot.Add.Scatter(dataListX, dataListY);
                dataPlot.Plot.Axes.SetLimits(dataXmin, dataXmax, dataYmin, dataYmax);
                dataPlot.Refresh();
            }

        }        
```