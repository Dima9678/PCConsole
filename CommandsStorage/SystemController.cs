using AudioSwitcher.AudioApi.CoreAudio;
using System.Diagnostics;
using System.Text.Json;

public class SystemController
{
    public void AudioOutputModeChanger(string inputCommand)
    {
        AudioDeviceController controller = new();
        controller.RunCommand(inputCommand);
    }
    public void ScreenModeChanger(string inputCommand)
    {
        ScreenController controller = new();
        controller.SwitchDevice(inputCommand);
    }
    public void PcTurnOff()
    {
        PowerController controller = new();
        controller.TurnOff();
        
    }
    public async Task TurnToSleep()
    {
        ConsoleInput input = new();
        TimeOnly sleepTime = input.ReadTime("Введите время");

        PowerController controller = new();
        TelegramMessages messages = new();
        controller.Sleep(sleepTime);
        await messages.SendMessage(sleepTime);
    }
}

public class WorkdayStorage
{
    private string shedulePath = "shedule.json";

    private void ReadJson()
    {
        Workday workday = JsonSerializer.Deserialize<Workday>(shedulePath);
    }
    private void WriteJson()
    {
        string str = string.Empty;

        var options = new JsonSerializerOptions
        {
            WriteIndented = true,
        };

        string serializatedText = JsonSerializer.Serialize(str, options);
        File.WriteAllText(shedulePath, serializatedText);
    }
}
public class WorkdayCalculate
{

}
public class Workday
{
    private string numberOfDay { get; }

    
}

public class AudioDeviceController
{
    private CoreAudioController controller = new CoreAudioController();
    public async Task RunCommand(string command)
    {
        if (command == "sdon")
        {
            await TurnOff();
        }
        else if (command == "sdof")
        {
            await TurnOn();
        }
    }

    private async Task TurnOff() 
    {
        var devices = await controller.GetPlaybackDevicesAsync();
        foreach (var device in devices)
        {

            if (device.FullName == "EG240Y (NVIDIA High Definition Audio)")
            {
                await device.SetAsDefaultAsync();
                Console.WriteLine("The audio device has been changed\nCurrent device: " + device.FullName + "\n");
                break;
            }
        }
    }

    private async Task TurnOn() 
    {
        var devices = await controller.GetPlaybackDevicesAsync();
        foreach (var device in devices)
        {

            if (device.FullName == "Динамики (High Definition Audio Device)")
            {
                await device.SetAsDefaultAsync();
                Console.WriteLine("The audio device has been changed\n Current device: " + device.FullName);
                break;
            }
        }
    }
}

public class ScreenController
{
    public void SwitchDevice(string command)
    {
        if (command == "do")
        {
            OneDisplay();
        }
        else if(command == "db")
        {
            TwoDisplays();
        }
    }

    public void OneDisplay() 
    {
        Process.Start("DisplaySwitch.exe", "/internal");
    }
    public void TwoDisplays() 
    {
        Process.Start("DisplaySwitch.exe", "/internal");
    }
}

public class PowerController
{
    public void Sleep(TimeOnly time)
    {
        Process.Start(new ProcessStartInfo
        {
            FileName = "powershell",
            Arguments =
            "-ExecutionPolicy Bypass -Command \"" +

            "$action = New-ScheduledTaskAction -Execute 'powershell.exe' -Argument '-WindowStyle Hidden -Command exit'" +

            $"$trigger = New-ScheduledTaskTrigger -Once -At '{time}'; " +

            "$settings = New-ScheduledTaskSettingsSet -WakeToRun; " +

            "Register-ScheduledTask " +
            "-TaskName 'WakePC' " +
            "-Action $action " +
            "-Trigger $trigger " +
            "-Settings $settings " +
            "-Force; " +

            "Add-Type -Name Sleep -Namespace Win32 -MemberDefinition '[DllImport(\\\"powrprof.dll\\\", SetLastError=true)] public static extern bool SetSuspendState(bool hibernate, bool forceCritical, bool disableWakeEvent);'; " +

            "[Win32.Sleep]::SetSuspendState($false, $false, $false)\"",

            Verb = "runas",
            UseShellExecute = true,
            CreateNoWindow = true
        });
    }
    public void TurnOff() 
    {
        Process.Start("shutdown", "/s /t 0");
    }
}