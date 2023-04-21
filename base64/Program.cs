using base64;
using System.IO;

using (StreamReader sr = new StreamReader("../../../file/8.png"))
{
    string Text;
    Text = sr.ReadToEnd();
    string png = Base64Code.Encode(Text);
    using (StreamWriter sw = new StreamWriter("../../../file/encodeimg.txt"))
    {
        sw.Write(png);
    }
}

using (StreamReader sr = new StreamReader("../../../file/encodeimg.txt"))
{
    string Text;
    Text = sr.ReadToEnd();
    string png = Base64Code.Decode(Text);
    using (StreamWriter sw = new StreamWriter("../../../file/img.png"))
    {
        sw.Write(png);
    }
}


//string decodingString = "123132ajdflaa";
//Console.WriteLine(Base64Code.Encode(decodingString));
////MTIzMTMyYWpkZmxh
////MTI=MTM=YW==Z===
//string encodingString = "YWRzYXNkMzEzMTIxMg==";
//Console.WriteLine(Base64Code.Decode(encodingString));
