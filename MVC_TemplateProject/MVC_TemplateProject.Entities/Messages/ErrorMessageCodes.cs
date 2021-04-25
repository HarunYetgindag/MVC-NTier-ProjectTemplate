using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVC_TemplateProject.Entities.Messages
{
    public enum ErrorMessageCodes
    {
        UsernameAlreadyExists = 101,
        EmailAlreadyExists = 102,
        UserIsNotActive = 151,
        UsernameOrPassWrong = 152,
        CheckYourEmail = 153,
        UserAlreadyActive = 154,
        ActivateIdDoesNotExists = 155,
        UserNotFound = 156,
        UserCouldNotUpdated = 157,
        UserCouldNotRemove = 158,
        UserCouldFind = 159,
        UserCouldNotInserted = 160
    }
}
