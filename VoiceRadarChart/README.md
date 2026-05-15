# VoiceRadarChart

A .NET command-line tool that reads acoustic formant data from a CSV file (exported from Praat) and generates a radar chart (spider chart) PNG image visualizing the first five vocal formants (F1–F5) at a specified time frame.

---

## Purpose

VoiceRadarChart is designed for phoneticians, speech researchers, and voice analysts who need a quick visual snapshot of the formant structure of a voice sample. Given a CSV file containing time-series acoustic measurements, the tool extracts the five formant frequencies (F1–F5) at a chosen frame and renders them as a radar chart.

---

## CSV Format

The input CSV file must contain the following headers in order:

| Column    | Description                        |
|-----------|------------------------------------|
| `time(s)` | Time stamp in seconds              |
| `nformants` | Number of formants detected      |
| `F1(Hz)`  | First formant frequency in Hz      |
| `B1(Hz)`  | First formant bandwidth in Hz      |
| `F2(Hz)`  | Second formant frequency in Hz     |
| `B2(Hz)`  | Second formant bandwidth in Hz     |
| `F3(Hz)`  | Third formant frequency in Hz      |
| `B3(Hz)`  | Third formant bandwidth in Hz      |
| `F4(Hz)`  | Fourth formant frequency in Hz     |
| `B4(Hz)`  | Fourth formant bandwidth in Hz     |
| `F5(Hz)`  | Fifth formant frequency in Hz      |
| `B5(Hz)`  | Fifth formant bandwidth in Hz      |

**Example row:**

```csv
time(s),nformants,F1(Hz),B1(Hz),F2(Hz),B2(Hz),F3(Hz),B3(Hz),F4(Hz),B4(Hz),F5(Hz),B5(Hz)
0.010,5,720.3,85.1,1180.6,102.4,2540.2,134.7,3620.8,200.1,4510.3,310.5
