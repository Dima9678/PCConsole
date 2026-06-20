public class TelegramMessages
{
    public async Task SendMessage(TimeOnly time)
    {
        string token = "8069679541:AAGjszqd2GVRCDozU6zehev50KbIcFhZct4";
        string chatId = "1214343117";

        using HttpClient client = new HttpClient();
        string url =
        $"https://api.telegram.org/bot{token}/sendMessage?chat_id={chatId}&text=PC will turn on on {time}\n{DateTime.Now}";

        await client.GetAsync(url);
        Console.WriteLine($"Время пробуждения пк: {time}");
    }
}
