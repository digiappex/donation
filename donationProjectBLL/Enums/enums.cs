using System;
using System.ComponentModel.DataAnnotations;

namespace donationProjectBLL.enums{
    public enum messageCode{
        [Display(Name="General exception occur.")]
        GENERAL_EXCEPTION=4000,
        [Display(Name="User Already Exisit.")]
        USER_ALREADY_EXISIT=4001,
        [Display(Name="User signedup successfully.")]
        USER_SIGNUP_SUCCESSFULL,
        [Display(Name="User signedup fail.")]
        USER_SIGNUP_FAIL,
        [Display(Name="User register successfully .")]
        USER_REGISTER_SUCESSFULLY,
        [Display(Name="Unable to register user.")]
        UNABLE_TO_REGISTER_USER,
        [Display(Name="Invalid login name or password.")]
        INVALID_CREDENTIALS,
        [Display(Name="Login Successfull.")]
        LOGIN_SUCCESSFULL,
        [Display(Name="No result return")]
        NO_RESULT_RETURNED,
        [Display(Name="CNIC and Area Id Required")]
        CNIC_AREAID_REQUIRED

    }
}