
namespace App;

public partial class ProgressBarPage : ContentPage {
    static CancellationTokenSource cancellationTokenSource;
    CancellationToken token;
    bool isRunning = true;

    public ProgressBarPage() {
        InitializeComponent();
    }

    private async void ButtonStartClicked(object sender, EventArgs e) {
        if (isRunning) {
            cancellationTokenSource = new CancellationTokenSource();
            token = cancellationTokenSource.Token;
            isRunning = false;
            WelcomeLabel.Text = "Solving..";

            await Task.Run(async () => {
                double result = 0;
                int percent = 0;

                for (double i = 0; i <= 1; i += 0.0000001) {
                    if (token.IsCancellationRequested) {
                        MainThread.BeginInvokeOnMainThread(() => {
                            ProgressLabel.Text = "0%";
                            WelcomeLabel.Text = "Stopped solving";
                            ProgressItself.Progress = 0;
                        });
                        return;
                    }

                    for (int j = 0; j < 25; j++) {
                        int d = j * j;
                    }

                    result += Math.Sin(i) * 0.0000001;

                    if (percent < (int)(i * 100)) {
                        percent = (int)(Math.Round(i * 100));

                        MainThread.BeginInvokeOnMainThread(() => {
                            ProgressLabel.Text = percent + "%";
                            ProgressItself.Progress = percent / 100.0;
                        });
                    }
                }
                MainThread.BeginInvokeOnMainThread(() => {
                    ProgressLabel.Text = "100%";
                    WelcomeLabel.Text = result.ToString();
                });
            }, token);
            isRunning = true;
        }
    }

    private void ButtonStopClicked(object sender, EventArgs e) {
        if (!isRunning) {
            cancellationTokenSource.Cancel();
            cancellationTokenSource.Dispose();
        }
    }
}