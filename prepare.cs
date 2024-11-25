using adjaassh;
using adjaamobiledevice;
using System.IO;


using namespace iCloudBypass_SDK
{

public string device {get , set};
public class prepare : iCloudBypass_SDK
{
 public bool preparedata()
 {
   bool result = false;
     using (WebClient icloud = new WebClient())
{
       try
       { 
         if(icloud.DownloadString("").Contains(""))
  {

    result = true;
  }
       }
       catch(Exception errorx)
       {
         result = false;
       }
 return result;
}  
 }
  
}
  
}
