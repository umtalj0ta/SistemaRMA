using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.Extensions.Configuration;
using MimeKit;

namespace SistemaRMA.Services;

public class EmailService
{
    private readonly IConfiguration _configuration;

    public EmailService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

public async Task EnviarEmailAsync(string destinatario, string assunto, string mensagem)
{
    Console.WriteLine("Inicio");

    var email = new MimeMessage();

    email.From.Add(new MailboxAddress(
        _configuration["EmailSettings:SenderName"],
        _configuration["EmailSettings:SenderEmail"]));

    email.To.Add(MailboxAddress.Parse(destinatario));

    email.Subject = assunto;

    email.Body = new TextPart("plain")
    {
        Text = mensagem
    };

    using var smtp = new SmtpClient();

    smtp.ServerCertificateValidationCallback = (s, c, h, e) => true;

    Console.WriteLine("A ligar");

    await smtp.ConnectAsync(
        _configuration["EmailSettings:SmtpServer"],
        int.Parse(_configuration["EmailSettings:Port"]!),
        SecureSocketOptions.StartTls);

    Console.WriteLine("Ligado");

    await smtp.AuthenticateAsync(
        _configuration["EmailSettings:SenderEmail"],
        _configuration["EmailSettings:Password"]);

    Console.WriteLine("Autenticado");

    await smtp.SendAsync(email);

    Console.WriteLine("Enviado");

    await smtp.DisconnectAsync(true);

    Console.WriteLine("Fiiiiiim");
}
}