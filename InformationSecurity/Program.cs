using InformationSecurity;

string text = "ЭТО СООБЩЕНИЕ СЛЕДУЕТ ОТПРАВИТЬ";
string key = "КОМБАЙН";

var enc = FirstLab.Encrypt(text, key);
Console.WriteLine(enc);

var dec = FirstLab.Decrypt(enc, key);
Console.WriteLine(dec);