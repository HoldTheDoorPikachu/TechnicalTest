using System.Text;
using Ulaw.ApplicationProcessor.Models;
using ULaw.ApplicationProcessor.Enums;


namespace ULaw.ApplicationProcessor
{
    public static class ApplicationHelper
    {

        public static string Process(Application app)
        {
            var result = new StringBuilder();

            if (app.DegreeGrade == DegreeGradeEnum.twoTwo)
            {
                result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", app.CourseCode, app.StartDate.ToLongDateString()));  //I'm not really happy with the repeated blocks of text, but I didn't come up with a very elegant solution...
                result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
            }
            else
            {
                if (app.DegreeGrade == DegreeGradeEnum.third)
                {
                    result.Append("<p/> Further to your recent application, we are sorry to inform you that you have not been successful on this occasion.");
                    result.Append("<br/> If you wish to discuss the decision further, or discuss the possibility of applying for an alternative course with us, please contact us at AdmissionsTeam@Ulaw.co.uk.");
                }
                else
                {
                    if (app.DegreeSubject == DegreeSubjectEnum.law || app.DegreeSubject == DegreeSubjectEnum.lawAndBusiness)
                    {
                        decimal depositAmount = 350.00M;

                        result.Append(string.Format("<p/> Further to your recent application, we are delighted to offer you a place on our course reference: {0} starting on {1}.", app.CourseCode, app.StartDate.ToLongDateString()));
                        result.Append(string.Format("<br/> This offer will be subject to evidence of your qualifying {0} degree at grade: {1}.", app.DegreeSubject.ToDescription(), app.DegreeGrade.ToDescription()));
                        result.Append(string.Format("<br/> Please contact us as soon as possible to confirm your acceptance of your place and arrange payment of the £{0} deposit fee to secure your place.", depositAmount.ToString()));
                        result.Append(string.Format("<br/> We look forward to welcoming you to the University,"));
                    }
                    else
                    {
                        result.Append(string.Format("<p/> Further to your recent application for our course reference: {0} starting on {1}, we are writing to inform you that we are currently assessing your information and will be in touch shortly.", app.CourseCode, app.StartDate.ToLongDateString()));
                        result.Append("<br/> If you wish to discuss any aspect of your application, please contact us at AdmissionsTeam@Ulaw.co.uk.");
                    }
                }
            }


            string response = ResponseHtml(app, result.ToString());
            return response;
        }

        //naming things is sometimes difficult.  I perfer elegant, descriptive, unique names.   Not really happy with this name, but lets go with it.
        private static string ResponseHtml(Application app, string innerHtml) //this IS a refactoring, but not really happy with it.  IMHO, it makes the code a bit more difficult to read and understand what it does... but it *may* reduce some maintenance in the future.
        {
            var result = new StringBuilder("<html><body><h1>Your Recent Application from the University of Law</h1>");
            result.Append(string.Format("<p> Dear {0}, </p>", app.FirstName));
            result.Append(innerHtml);
            result.Append("<br/> Yours sincerely,");
            result.Append("<p/> The Admissions Team,");
            result.Append(string.Format("</body></html>")); 

            return result.ToString();
        }
    }
}

