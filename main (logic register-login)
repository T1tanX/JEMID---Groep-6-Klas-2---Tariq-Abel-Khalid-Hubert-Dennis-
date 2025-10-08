using System;
using System.Collections.Generic;
using System.Net;
using System.Text;
using System.IO;
using System.Security.Cryptography;
using System.Threading;

var users = new Dictionary<string, string>();

string Hash(string input)
{
    using var sha = SHA256.Create();
    var bytes = sha.ComputeHash(Encoding.UTF8.GetBytes(input));
    return Convert.ToHexString(bytes);
}

string url = "http://localhost:8080/";
var listener = new HttpListener();
listener.Prefixes.Add(url);
listener.Start();

Console.WriteLine("Server running at " + url);

try
{
    System.Diagnostics.Process.Start(new System.Diagnostics.ProcessStartInfo
    {
        FileName = url + "website.html",
        UseShellExecute = true
    });
}
catch { }

while (true)
{
    var context = listener.GetContext();
    var request = context.Request;
    var response = context.Response;

    if (request.HttpMethod == "POST")
    {
        using var reader = new StreamReader(request.InputStream, request.ContentEncoding);
        string data = reader.ReadToEnd();

        var form = ParseForm(data);

        if (request.Url.AbsolutePath.EndsWith("register"))
        {
            string user = form.GetValueOrDefault("username") ?? form.GetValueOrDefault("email") ?? "";
            string pass = form.GetValueOrDefault("password") ?? "";
            string confirm = form.GetValueOrDefault("confirm") ?? "";

            if (string.IsNullOrWhiteSpace(user) || string.IsNullOrWhiteSpace(pass))
            {
                Redirect(response, "website.html?ok=0&msg=missing%20fields");
            }
            else if (!string.IsNullOrEmpty(confirm) && confirm != pass)
            {
                Redirect(response, "website.html?ok=0&msg=passwords%20do%20not%20match");
            }
            else if (users.ContainsKey(user))
            {
                Redirect(response, "website.html?ok=0&msg=user%20exists");
            }
            else
            {
                users[user] = Hash(pass);
                Redirect(response, "website2.html?ok=1&msg=account%20created");
            }
        }
        else if (request.Url.AbsolutePath.EndsWith("login"))
        {
            string user = form.GetValueOrDefault("username") ?? form.GetValueOrDefault("email") ?? "";
            string pass = form.GetValueOrDefault("password") ?? "";

            if (!users.ContainsKey(user) || users[user] != Hash(pass))
            {
                Redirect(response, "website2.html?ok=0&msg=invalid%20credentials");
            }
            else
            {
                Redirect(response, $"website2.html?ok=1&msg=welcome%20{Uri.EscapeDataString(user)}");
            }
        }
    }
    else 
    {
        string filePath = "." + request.Url.AbsolutePath.Replace("/", "\\");
        if (Directory.Exists(filePath))
            filePath += "\\index.html";
        if (!File.Exists(filePath))
            filePath = "./website.html";

        byte[] buffer = File.ReadAllBytes(filePath);
        response.ContentType = "text/html";
        response.ContentLength64 = buffer.Length;
        response.OutputStream.Write(buffer, 0, buffer.Length);
        response.OutputStream.Close();
    }
}

void Redirect(HttpListenerResponse res, string location)
{
    res.StatusCode = 302;
    res.RedirectLocation = location;
    res.Close();
}

Dictionary<string, string> ParseForm(string data)
{
    var dict = new Dictionary<string, string>();
    foreach (var pair in data.Split('&', StringSplitOptions.RemoveEmptyEntries))
    {
        var kv = pair.Split('=', 2);
        if (kv.Length == 2)
        {
            dict[WebUtility.UrlDecode(kv[0])] = WebUtility.UrlDecode(kv[1]);
        }
    }
    return dict;
}
