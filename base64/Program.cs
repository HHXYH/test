using base64;
using System.IO;


using(FileStream fs = new FileStream("../../../file/8.png", FileMode.OpenOrCreate, FileAccess.Read))
{
    byte[] buffer = new byte[fs.Length];
    fs.Read(buffer,0,buffer.Length);
    string encodefile=Base64Code.EncodeByByte(buffer);
    using (StreamWriter sw = new StreamWriter("../../../file/8.txt"))
    {
        sw.Write(encodefile);
    }
}
using(StreamReader sr = new StreamReader("../../../file/8.txt"))
{
    byte[] bytes=Base64Code.DecodeToByte( sr.ReadToEnd());
    using(FileStream fs=new FileStream("../../../file/img1.png",FileMode.OpenOrCreate,FileAccess.Write))
    {
        fs.Write(bytes,0,bytes.Length);
    }
}