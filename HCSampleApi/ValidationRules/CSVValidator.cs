using DataAccess.Model;
using FluentValidation;
using HCSampleApi.Model;
using System.Net;

namespace HCSampleApi.ValidationRules
{
    public class CSVValidator:AbstractValidator<HotelModel>
    {

        public CSVValidator()
        {

            RuleFor(x => x.Name).Must(UTF8Control);

            RuleFor(x => x.Uri).Must(IsValidUri);

            RuleFor(x => x.Stars).Must(IsStarValid);



        }

        private bool IsStarValid(int arg)
        {
            

            if ( arg <=5 && arg >= 0  )
            {
                return true;

            }
            else
            {

                return false;

            }


        }

        private bool IsValidUri(string url)
        {
            //try
            //{
            //    //Creating the HttpWebRequest
            //    HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
            //    //Setting the Request method HEAD, you can also use GET too.
            //    request.Method = "HEAD";
            //    //Getting the Web Response.
            //    HttpWebResponse response = request.GetResponse() as HttpWebResponse;
            //    //Returns TRUE if the Status code == 200
            //    response.Close();
            //    return (response.StatusCode == HttpStatusCode.OK);
            //}
            //catch
            //{
            //    //Any exception will returns false.
            //    return false;
            //}
            return true;
        }

        private bool UTF8Control(string arg)
        {
            //bool isUtf8 = true;

            //foreach (char c in arg.GetCharArray())
            //{
            //    if (!c.isValidUtf8Character)
            //        isUtf8 = false;
            //    return isUtf8;
            //}

            return true;
        }
    }


    }

