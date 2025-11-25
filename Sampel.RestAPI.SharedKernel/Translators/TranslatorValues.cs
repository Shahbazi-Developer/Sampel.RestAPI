namespace Sampel.RestAPI.SharedKernel.Translators;
public class TranslatorValues
{
    #region ValidationMessage

    #region Commom

    public const string SOME_KIND_OF_ERROR_OCCURRED_IN_THE_API = "خطای پیش بینی نشده رخ داده است، لطفا با پشتیبان تماس حاصل نمایید";
    public const string VALIDATION_ERROR_NOT_EMPTY = "{0} باید مقدار داشته باشد.";
    public const string VALIDATION_ERROR_NOT_NULL = "{0} نباید نال باشد.";
    public const string VALIDATION_ERROR_IS_REQUIRED = "{0} اجباری است.";
    public const string VALIDATION_ERROR_IS_DUPLICATED = "{0} تکراری است.";
    public const string VALIDATION_ERROR_NOT_FOUND = "{0} یافت نشد.";
    public const string VALIDATION_ERROR_MUST_BE_UNIQUE = "{0} باید یکتا باشد";
    public const string VALIDATION_ERROR_NOT_EXIST = "{0} وجود ندارد.";
    public const string VALIDATION_ERROR_NOT_EXIST_CLEARANCE_REQUEST_GOODS = "{0} یا {1} وجود ندارد ";
    public const string VALIDATION_ERROR_NOT_EXIST_LAB_MEMBER = "{0} یا {1} وجود ندارد ";
    public const string VALIDATION_ERROR_MAX_LENGTH = "{0} باید حداکثر {1} کاراکتر باشد";
    public const string VALIDATION_ERROR_MIN_LENGTH = "{0} باید حداقل {1} کاراکتر باشد";
    public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = "{0} باید بین {2} و {1} کاراکتر باشد";
    public const string VALIDATION_ERROR_MAX_VALUE = "مقدار {0} باید کوچکتر {1} باشد";
    public const string VALIDATION_ERROR_MIN_VALUE = "مقدار {0} باید بزرگتر {1} باشد";
    public const string VALIDATION_ERROR_VALUE_BETWEEN = "{0} باید بین {2} و {1} باشد";
    public const string VALIDATION_ERROR_NOT_EQUAL = "{0} برابر  {1} نیست ";
    public const string VALIDATION_ERROR_EQUAL = "{0}باید برابر {1} باشد";
    public const string VALIDATION_ERROR_NOT_ACCESS = "شما به {0} دسترسی ندارید";
    public const string VALIDATION_ERROR_NOT_AUTHENTICATED = "شما احراز هویت نشده اید.";
    public const string VALIDATION_ERROR_NOT_AUTHORIZED = "دسترسی شما احراز نشده است";
    public const string VALIDATION_ERROR_NOT_VALID = "مقدار {0} نامعتبر است.";
    public const string VALIDATION_ERROR_MUST_BE = "{0} باید {1} باشد.";
    public const string VALIDATION_ERROR_MUST_NOT_BE = "{0} نباید {1} باشد.";
    public const string VALIDATION_ERROR_MUST_HAVE = "{0} باید {1} داشته باشد.";
    public const string VALIDATION_ERROR_MUST_HAVE_NOT = "{0} نباید {1} داشته باشد.";
    public const string VALIDATION_ERROR_FORMAT_INCORRECT = "فرمت {0} نا معتبر است.";
    public const string VALIDATION_ERROR_FORM_VALUE_LESS_THAN_TO_VALUE = "مقدار {0} از {1} کوچکتر است.";
    public const string VALIDATION_ERROR_FORM_VALUE_GREATER_THAN_TO_VALUE = "مقدار {0} از {1} بزرگتر است.";
    public const string VALIDATION_ERROR_REQUEST = "درخواست شما نامعتبر است";
    public const string VALIDATION_INPUT_MODEL = "ورودی";
    public const string NameDefault = "مشتری گرامی";
    public const string VALIDATION_ERROR_MUST_HAVE_BE_NUMBER = "{0} باید مقدار عددی باشد";
    public const string VALIDATION_ERROR_MUST_HAVE_BE_NationalCode = "{0} باید {1} رقم و عددی و معتبر باشد";
    public const string VALIDATION_ERROR_CAN_NOT_GET_TOKEN = "خطا در ورود به سامانه";
    public const string THE_ONLY_ALLOWED_FORMATS_ARE_PDF_JPEG_AND_JPG = "فرمت های مجاز فقط عکس و پی دی اف می باشند ، فرمت فایل ارسالی قابل قبول نمی باشد";
    public const string THE_ONLY_ALLOWED_FORMATS_ARE_PNG = "فرمت های مجاز فقط پی ان جی می باشند ، فرمت فایل ارسالی قابل قبول نمی باشد";
    public const string THE_ONLY_ALLOWED_FORMATS_ARE_Exel = "فرمت های مجاز فقط اکسل می باشند ، فرمت فایل ارسالی قابل قبول نمی باشد";
    public const string THE_SIGNATURE_NOT_VALID = "امضای فایل ارسال شده معتبر نمیباشد!";
    public const string THE_MAXIMUM_FILE_SIZE_IS_10_MB = "حداکثر حجم فایل 10 مگابایت می باشد";
    public const string THE_MAXIMUM_FILE_SIZE_IS_5_MB = "حداکثر حجم فایل 5 مگابایت می باشد";
    public const string PLEASE_ENTER_THE_FEE_AMOINT_FIRST = "لطفاً ابتدا مبلغ کارمزد را وارد نمائید";
    public const string THE_OPERATION_WAS_NOT_SUCCESSFUL = "عملیات برای {0} موفقیت آمیز نبود";
    public const string VALIDATION_ERROR_INVALID_ENUM = " شناسه {0} نامعتبر است.";


    public const string VALIDATION_ERROR_FILE_GROUP_EXIST = "گروه فایل وارد شده نامعتبر است.";
    public const string VALIDATION_ERROR_IMAGE_TYPE_EXIST = "نوع تصویر وارد شده نامعتبر است.";
    public const string VALIDATION_ERROR_DOC_TYPE_EXIST = "نوع سند وارد شده نامعتبر است.";
    public const string VALIDATION_ERROR_IMAGE_DOCUMENT_TYPE_EXIST = "نوع سند تصویری وارد شده نامعتبر است.";
    public const string VALIDATION_ERROR_VIDEO_TYPE_EXIST = "نوع ویدئو وارد شده نامعتبر است.";
    public const string VALIDATION_ERROR_NO_SCOPE_FOR_ACTIVITY = "زمینه فعالیت با کد {0} وجود ندارد";




    #endregion

    #region lab

    public const string VALIDATION_ERROR_THE_START_DATE_MUST_NOT_BE_GREATER_THAN_THE_END_DATE = "{0} نباید از تاریخ پایان بزرگتر باشد ";
    public const string THE_CERTIFICATE_EXPIRATION_DATE_MUST_NOT_BE_LESS_THAN_THE_ESTABLISHMENT_DATE = "تاریخ پایان اعتبار گواهینامه نباید از تاریخ تأسیس کوچکتر باشد";
    public const string THE_ESTABLISHMENT_DATE_SHOULD_NOT_BE_GREATER_THAN_TODAY_S_DATE = "تاریخ تأسیس نباید از تاریخ امروز بزرگتر باشد";
    public const string THE_CERTIFICATE_START_DATE_MUST_NOT_BE_LESS_THAN_THE_ESTABLISHMENT_DATE = "تاریخ شروع گواهینامه نباید کوچکتر یا مساوی تاریخ تأسیس باشد";
    public const string VALIDATION_ERROR_THE_ENTERED_EMAIL_FORMAT_IS_NOT_CORRECT = "فرمت ایمیل وارد شده صحیح نمی باشد";
    public const string VALIDATION_ERROR_INVALID_FORMAT = "فرمت {0} وارد شده صحیح نمی باشد";
    public const string THE_LABORATORY_WITH_IS_NOT_EXIST = "آزمایشگاه با {0} مورد نظر موجود نمی باشد";
    public const string VALIDATION_ERROR_EXAMINATIONTYPE_IS_ALLOCATED = "این نوع آزمایش به یک آزمایشگاه اختصاص داده شده است";
    public const string VALIDATION_ERROR_EQUIPMENT_IS_ALLOCATED = "این تجهیزات به یک آزمایشگاه اختصاص داده شده است";
    public const string VALIDATION_ERROR_NOT_EXIST_TO_PARAMETER = "{0} یا {1} وجود ندارد";
    public const string Name = "نام";
    public const string Id = "شناسه";
    public const string BusinessId = "شناسه تجاری";
    public const string Location = "مکان";
    public const string Address = "آدرس";
    public const string HSCode = "کد تعرفه های دامنه فعالیت";
    public const string LicenceNO = "شماره گواهینامه تایید صلاحیت";
    public const string LicenceStartDate = "تاریخ شروع مجوز";
    public const string LicenceEndDate = "تاریخ پایان مجوز";
    public const string TelNo = "شماره تلفن";
    public const string Email = "ایمیل";
    public const string SamplerAvailable = "نمونه بردار";
    public const string TransferAvailable = "انتغال دهنده";
    public const string ManagerInformation = "اطلاعات مدیر";
    public const string Active = "فعال";
    public const string Deleted = "حذف";
    public const string LastName = "نام خانوادگی";
    public const string PhoneNumber = "شماره تماس";
    public const string EmailAddress = "آدرس ایمیل";
    public const string Value = "ارزش";
    public const string CreatedByUserId = "ایجاد شده توسط شناسه کاربر";
    public const string CreatedDateTime = "تاریخ ایجاد شده";
    public const string ModifiedByUserId = "اصلاح شده توسط شناسه کاربر";
    public const string ModifiedDateTime = "تاریخ اصلاح شده";
    public const string Title = "عنوان";
    public const string NewRequest = "درخواست جدید";
    public const string Pending = "در انتظار بررسی";
    public const string Approved = "قبول شده";
    public const string Rejected = "رد شده";
    public const string PositionId = "شناسه سمت";
 

    public const string NationalID = "کد ملی";
    public const string NationalId = "کد ملی";
    public const string EmployeeID = "شناسه کارمند";
    public const string FirstName = "نام";
    public const string EquipmentId = "شناسه تجهیزات";
    public const string ExaminationTypeId = "شناسه آزمون";

    public const string ZipCode = "کد پستی";
    public const string FieldOfActivity = "ضمینه فعالیت";
    public const string CertificateID = "شناسه گواهی";
    public const string Latitude = "عرض جغرافیایی";
    public const string Longitude = "طول جغرافیایی";
    public const string StablishmentDate = "تاریخ تأسیس";
    public const string CertificateValidityStartDate = "تاریخ شروع اعتبار گواهینامه";
    public const string CertificateValidityEndDate = "تاریخ پایان اعتبار گواهینامه";
    public const string LabRequested_PhoneNumber = "شماره تلفن درخواست دهنده";
    public const string LabRequested_FullName = "نام و نام خانوادگی درخواست دهنده";
    public const string Owner_FullName = "نام مدیرعامل آزمایشگاه";
    public const string Owner_NationalId = "کد ملی مدیرعامل آزمایشگاه";
    public const string Owner_NationalID = "کد ملی مدیرعامل آزمایشگاه";
    public const string Owner_PhoneNumber = "شماره تماس مدیرعامل آزمایشگاه";
    public const string INVALID_FORMAT_FOR_ACTIVITY_FIELD_RANGE = "{0} فرمت نامعتبر برای بازه زمینه فعالیت";
    public const string THE_EXEL_FILE_FORMAT_IS_INVALID = "فرمت فایل اکسل نامعتبر می باشد";


    public const string HsCodeExelFile = "فایل اکسل";
    public const string EmployeeType = "نوع کارمند";
    public const string LabId = "شناسه آزمایشگاه";
    public const string labId = "شناسه آزمایشگاه";
    public const string LabID = "شناسه آزمایشگاه";


    public const string EmployeeId = "شناسه کارمند";
    public const string EmployeeProfileId = "شناسه پروفایل کارمند";
    public const string EmployeeProfileID = "شناسه پروفایل کارمند";
    public const string SeasonCode = "کد فصل";
    public const string PositionID = "شناسه سمت";
    public const string UserId = "شناسه کاربر";
    public const string ID = "شناسه";
    public const string labType = "نوع آزمایشگاه";
    public const string LabType = "نوع آزمایشگاه";

    public const string OwnerPhoneNumber = "شماره تماس مدیرعامل آزمایشگاه";
    public const string OwnerNationalID = "کد ملی صاحب کالا";
    public const string ResultDescription = "شرح نتیجه";
    public const string THE_LABORATORY_WITH_THE_ENTERED_NATIONAL_ID_HAS_ALREADY_BEEN_REGISTERED_IN_THE_SYSTEM = "شناسه ملی آزمایشگاه قبلاً در سیستم ثبت شده است";
    public const string A_USER_WITH_THIS_NATIONAL_ID_AND_PHONE_NUMBER_ALREADY_EXISTS_IN_THIS_LABORATORY = "با این شماره تماس این کاربر در آزمایشگاه وجود دارد";

    public const string OwnerLastName = "نام خانوادگی صاحب آزمایشگاه";
    public const string OwnerFirstName = "نام صاحب آزمایشگاه";
    public const string LegalNationalId = "کد ملی";
    public const string Owner_LastName = "نام خانوادگی صاحب آزمایشگاه";
    public const string Owner_FirstName = "نام صاحب آزمایشگاه";
    public const string LabCode = "کد آزمایشگاه";
    public const string documentTypeId = "شناسه نوع سند";
    public const string ProfileId = "شناسه پروفایل";
    public const string There_Was_A_Problem_Removing_The_User_From_The_System = "حذف کاربر از سامانه با مشکل مواجه شد";
    public const string There_Was_A_Problem_Create_The_User_From_The_System = "عملیات ساختن کاربر در سامانه با مشکل مواجه شد";





    #endregion

    #region Request

    public const string CottageNumber = "شماره کوتاژ";
    public const string LaboratoryId = "شناسه آزمایشگاه";
    public const string RequestDate = "تاریخ درخواست";
    public const string Description = "شرح درخواست";
    public const string DeclarationDate = "تاریخ اظهارنامه";
    public const string OwnerName = "شناسه صاحب کالا ";
    public const string OwnerMobileNumber = "شماره موبایل مالک";
    public const string OwnerNationalId = "کد ملی صاحب کالا";
    public const string Status = "وضعیت";
    public const string TariffCode = "کد تعرفه";
    public const string BusinessDescription = "شرح کسب و کار";
    public const string TariffDescription = "شرح تعرفه";
    public const string CustomsAssessmentLocation = "گمرک محل ارزیابی";
    public const string GoodsId = "شناسه کالا";
    public const string Fee = "هزینه";
    public const string Amount = "کارمزد";
    public const string Currency = "ارز";
    public const string WaitForCalculation = "در انتظار وارد کردن کارمزد";
    public const string RegisteredFee = "کارمزد وارد شده";
    public const string WaitForPayment = "در انتظار پرداخت کارمزد";
    public const string Paid = "پرداخت شده";
    public const string WaitForInsertResult = "در انتظار وارد کردن نتیجه";
    public const string InsertAndEditResult = "نتیجه وارد شده";
    public const string EndOfRequst = "پایان درخواست";

    public const string CahngeStatusNotValid = "تغییر وضعیت امکان پذیر نیست.";
    public const string VALIDATION_ERROR_MAXIMUM_VALUE = "حداکثر مبلغ وارد شده {0} می باشد";


    public const string GoodsID = "شناسه کالا";
    public const string RequestGoodsId = "شناسه درخواست کالا";
    public const string RequestHistoryId = "شناسه تاریخچه درخواست";

    #endregion

    #region RequestResult

    public const string FileContent = "محتوای فایل";
    public const string RequestID = "شناسه درخواست";
    public const string Request = "درخواست";
    public const string request = "درخواست";
    public const string Key = "کلید";
    public const string Content = "محتوا";
    public const string CANNOT_SET_STATUS_TO_REGISTEREDFEE_FEEAMOUNT_MUST_BE_GREATER_THEN_0 = "نمی توان وضعیت را به هزینه ثبت شده تنظیم کرد.مقدار کارمزد نمی تواند خالی باشد.";
    public const string CANNOT_SET_STATUS_TO_INSERTRESULT_FILECONTENT_CANNOT_BE_NULL = "نمی توان وضعیت را به درج نتیجه تنظیم کرد.محنوای فایل نمی تواند خالی باشد";
    public const string CANNOT_SET_STATUS_TO_INSERTRESULT_RESULTDESCRIPTION_CANNOT_BE_NULL_OR_EMPTY = "نمی توان وضعیت را به درج نتیجه تنظیم کرد.توضیحات نتیجه نمی تواند خالی باشد";
    public const string CANNOT_TRANSITION_FROM_CURRENT_TO_NEXT_STATUS = "نمی توان وضعیت را از {0} به {1} تغییر داد.";
    public const string CANNOT_SET_FEE_ON_THIS_CURRENT_STATUS = "ثبت کارمزد در این مرحله امکان پذیر نمی باشد";
    public const string CHANGING_THE_STATUS_IS_NOT_POSSIBLE_AT_THIS_STAGE = "تغییر وضعیت در این مرحله امکان پذیر نمی باشد.";
    public const string IT_IS_NOT_POSSIBLE_TO_INSERT_RESULT_AT_THIS_STAGE = "ثبت توضیحات در این وضعیت قابل انجام نیست.";
    public const string IT_IS_NOT_POSSIBLE_TO_EXPECTED_DATE_AT_THIS_STAGE = "ثبت تاریخ پیشبینی شده در این وضعیت قابل انجام نیست.";
    public const string FILE_DELETION_IS_NOT_POSSIBLE_AT_THIS_STAGE = "حذف فایل در این وضعیت قابل انجام نیست.";
    public const string FILE_UPLOADING_IS_NOT_POSSIBLE_AT_THIS_STAGE = "آپلود فایل در این وضعیت قابل انجام نیست.";
    public const string THE_ENTERED_DATE_CANNOT_BE_YOUNGER_THAN_TODAYS_DATE = "تاریخ وارد شده نمی تواند از تاریخ امروز کوچکتر باشد.";


    public const string RequestId = "شناسه درخواست";


    #endregion

    #region LabProfile & LabMember

    public const string Owner = "صاحب آزمایشگاه";
    public const string Lastname = "نام";
    public const string Firsname = "نام خانوادگی";
    public const string ActivityScope = "نام";
    public const string ActivityField = "نام";
    public const string TechnicalManager = "مسول فنی آزمایشگاه";

    #endregion

    #region SamtLaboratory

    public const string THE_DESIRED_ITEM_EXISTS = "{0}  وجود دارد";


    #endregion


    #endregion


    #region Logs

    #region Handler Messages

    public const string HANDLER_RUN_LOG = "Came to {0} handler";
    public const string HANDLER_COMPLETE_OPERATION_LOG = "Finish {0} handler process";
    public const string HANDLER_CATCH_EXCEPTION_LOG = "Catch exception in {0} handler proccess and exception is : {1}";
    public const string HANDLER_READ_QUERY_LOG = "Execute read query in {0} handler";

    #endregion

    #endregion

    #region FileManagement

    public const string THE_MINIMUM_SIZE_SELECTED_MUST_BE = "حداقل سایز انتخاب شده باید {0} باشد";
    public const string THE_MAXIMUM_SIZE_SELECTED_MUST_BE = "حداکثر سایز انتخاب شده باید {0} باشد";
    public const string FILE_GROUP_IS_NOT_SUPPORTED = "گروه فایل {0} پشتیبانی نمی شود";

    public const string MinSize = "حداقل اندازه";
    public const string MaxSize = "حداکثر اندازه";
    public const string ImageType = "نوع عکس";
    public const string DocType = "نوع سند";
    public const string VideoType = "نوع فلیم";
    public const string File = "فایل";
    public const string DocumentFileId = "شناسه فایل سند";



    #endregion


    #region Season

    public const string VALIDATION_ERROR_NOT_LAB_EXIST = "درخواستی برای آزمایشگاه مورد نظر موجود نمی باشد.";

    public const string DocumentCategoryId = "شناسه سند";
    public const string DocumentTypeId = "شناسه نوع سند";
    public const string HsCodeExel = "فایل اکسل";


    #endregion

}