# Biosensor GUI
## Brief Description
A graphical user interface (GUI) designed to work with the corresponding [biosensor firmware](https://github.com/eftimovK/BioSensor-Readout).

## Features

- Three types of measurement: select between three excitation signals
- Configurable measurement parameters (e.g., frequency, amplitude) directly through the GUI before starting a measurement
- Real-Time display of incoming biosensor data
- Save plotted data to a .txt file for post-processing (e.g., using MATLAB).

## How to Run

1. Connect the biosensor board to your PC via USB
2. Launch the GUI and select the correct **COM port**
3. Configure measurement parameters (frequency, waveform, etc.) in the provided input fields
4. Specify the **file path** for saving measurement data
5. Start the measurement!

## 💡 Hints

- **Hard-Coded Electrode Pins**  
  The electrode pin assignments are hard-coded in the microcontroller firmware. Ensure your physical setup matches the expected configuration.

- **Microcontroller Running at Launch**  
  Make sure the microcontroller program is running from the very beginning when you launch the GUI. This means, if you restart the GUI, restart the firmware as well; this ensures the microcontroller is in the right state to receive commands.

- **Configure Parameters First**  
  Set all measurement parameters before clicking the "Start" button

- **Pay attention to Parameter Ranges**  
  Hover over each field to see tooltips with expected range of values
