namespace Star_Citizen_Handle_Query.Classes;

public class TypeAssistant {
  public event EventHandler Idled = delegate { };
  public int WaitingMilliSeconds { get; set; }
  readonly System.Threading.Timer waitingTimer;

  public TypeAssistant(int waitingMilliSeconds = 600) {
    WaitingMilliSeconds = waitingMilliSeconds;
    waitingTimer = new System.Threading.Timer(p => {
      Idled(this, EventArgs.Empty);
    });
  }
  public void TextChanged(bool forceChanged = false) {
    waitingTimer.Change(forceChanged ? 0 : WaitingMilliSeconds, Timeout.Infinite);
  }
}


/*
https://stackoverflow.com/a/33777265
Usage:
public partial class Form1 : Form
{
    TypeAssistant assistant;
    public Form1()
    {
        InitializeComponent();
        assistant = new TypeAssistant();
        assistant.Idled += assistant_Idled;          
    }

    void assistant_Idled(object sender, EventArgs e)
    {
        this.Invoke(
        new MethodInvoker(() =>
        {
            // do your job here
        }));
    }

    private void yourFastReactingTextBox_TextChanged(object sender, EventArgs e)
    {
        assistant.TextChanged();
    }
}
*/