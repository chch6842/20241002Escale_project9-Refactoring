using System.Net.Http.Headers;

public class LineNotifyService : BaseClass
{
    /// <summary>
    /// LINE Notify API 網址
    /// </summary> 
    public string LineNotifyUrl { get; } = "https://notify-api.line.me/api/notify";
    /// <summary>
    /// LINE Notify API 權杖
    /// </summary> 
    public string Token { get; set; } = "";
    /// <summary>
    /// LINE Notify 訊息內容
    /// </summary>
    public string MessageText { get; set; } = "";
    /// <summary>
    /// LINE Notify 圖片網址
    /// </summary>
    public string ImageUrl { get; set; } = "";
    /// <summary>
    /// 建構子
    /// </summary>
    public LineNotifyService()
    {
        SetData("", "");
    }
    /// <summary>
    /// 建構子
    /// </summary>
    /// <param name="token">LINE Notify API 權杖</param>
    public LineNotifyService(string token)
    {
        SetData(token, "");
    }
    /// <summary>
    /// 建構子
    /// </summary>
    /// <param name="token">LINE Notify API 權杖</param>
    /// <param name="messageText">LINE Notify 訊息內容</param>
    public LineNotifyService(string token, string messageText)
    {
        SetData(token, messageText);
    }
    /// <summary>
    /// 設定權杖與訊息內容
    /// </summary>
    /// <param name="token">LINE Notify API 權杖</param>
    /// <param name="messageText">LINE Notify 訊息內容</param>
    private void SetData(string token, string messageText)
    {
        Token = token;
        MessageText = messageText;
    }
    /// <summary>
    /// 送出 LINE Notify 訊息
    /// </summary>
    /// <param name="message">LINE Notify 訊息內容</param>
    /// <param name="token">LINE Notify API 權杖</param>
    public string SendMessage(string message = "", string token = "")
    {
        string str_message = "";

        if (!string.IsNullOrEmpty(token)) Token = token;
        if (!string.IsNullOrEmpty(message)) MessageText = message;
        if (!string.IsNullOrEmpty(Token) && !string.IsNullOrEmpty(MessageText))
        {
            try
            {
                using var httpClient = new HttpClient();
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/x-www-form-urlencoded"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var content = new Dictionary<string, string>();
                content.Add("message", MessageText);
                httpClient.PostAsync(LineNotifyUrl, new FormUrlEncodedContent(content));
            }
            catch (Exception ex)
            {
                str_message = ex.Message;
            }
        }
        return str_message;
    }
    /// <summary>
    /// 送出 LINE Notify 圖片訊息
    /// </summary>
    /// <param name="imageUrl">LINE Notify 圖片來源(絶對路徑)</param>
    /// <param name="message">LINE Notify 訊息內容</param>
    /// <param name="token">LINE Notify API 權杖</param>
    /// <returns></returns>
    public string SendImageMessage(string imageUrl, string message = "", string token = "")
    {
        string str_message = "";


        if (!string.IsNullOrEmpty(token)) Token = token;
        if (!string.IsNullOrEmpty(message)) MessageText = message;
        if (!string.IsNullOrEmpty(Token) && !string.IsNullOrEmpty(MessageText) && !string.IsNullOrEmpty(imageUrl))
        {
            try
            {
                using var httpClient = new HttpClient();
                FileStream img = File.OpenRead(imageUrl);
                httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("multipart/form-data"));
                httpClient.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", Token);
                var body = new MultipartFormDataContent();
                body.Add(new StringContent(MessageText), "message");
                if (img != Stream.Null)
                {
                    var imgFile = new StreamContent(img);
                    body.Add(imgFile, "imageFile", "*");
                }
                httpClient.PostAsync(LineNotifyUrl, body);
            }
            catch (Exception ex)
            {
                str_message = ex.Message;
            }
        }
        return str_message;
    }
}