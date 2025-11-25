namespace Sampel.RestAPI.SharedKernel.Translators;
public class TranslatorKeys
{
    #region ValidationMessage

    #region Common

    public const string SOME_KIND_OF_ERROR_OCCURRED_IN_THE_API = nameof(SOME_KIND_OF_ERROR_OCCURRED_IN_THE_API);
    public const string VALIDATION_ERROR_NOT_EMPTY = nameof(VALIDATION_ERROR_NOT_EMPTY);
    public const string VALIDATION_ERROR_INVALID_ENUM = nameof(VALIDATION_ERROR_INVALID_ENUM);
    public const string VALIDATION_ERROR_NOT_NULL = nameof(VALIDATION_ERROR_NOT_NULL);
    public const string VALIDATION_ERROR_IS_REQUIRED = nameof(VALIDATION_ERROR_IS_REQUIRED);
    public const string VALIDATION_ERROR_IS_DUPLICATED = nameof(VALIDATION_ERROR_IS_DUPLICATED);
    public const string VALIDATION_ERROR_NOT_FOUND = nameof(VALIDATION_ERROR_NOT_FOUND);
    public const string VALIDATION_ERROR_MUST_BE_UNIQUE = nameof(VALIDATION_ERROR_MUST_BE_UNIQUE);
    public const string VALIDATION_ERROR_NOT_EXIST = nameof(VALIDATION_ERROR_NOT_EXIST);
    public const string VALIDATION_ERROR_NOT_EXIST_CLEARANCE_REQUEST_GOODS = nameof(VALIDATION_ERROR_NOT_EXIST_CLEARANCE_REQUEST_GOODS);
    public const string VALIDATION_ERROR_NOT_EXIST_LAB_MEMBER = nameof(VALIDATION_ERROR_NOT_EXIST_LAB_MEMBER);
    public const string VALIDATION_ERROR_MAX_LENGTH = nameof(VALIDATION_ERROR_MAX_LENGTH);
    public const string VALIDATION_ERROR_MIN_LENGTH = nameof(VALIDATION_ERROR_MIN_LENGTH);
    public const string VALIDATION_ERROR_STRING_LENGTH_BETWEEN = nameof(VALIDATION_ERROR_STRING_LENGTH_BETWEEN);
    public const string VALIDATION_ERROR_MAX_VALUE = nameof(VALIDATION_ERROR_MAX_VALUE);
    public const string VALIDATION_ERROR_MIN_VALUE = nameof(VALIDATION_ERROR_MIN_VALUE);
    public const string VALIDATION_ERROR_VALUE_BETWEEN = nameof(VALIDATION_ERROR_VALUE_BETWEEN);
    public const string VALIDATION_ERROR_NOT_EQUAL = nameof(VALIDATION_ERROR_NOT_EQUAL);
    public const string VALIDATION_ERROR_EQUAL = nameof(VALIDATION_ERROR_EQUAL);
    public const string VALIDATION_ERROR_NOT_ACCESS = nameof(VALIDATION_ERROR_NOT_ACCESS);
    public const string VALIDATION_ERROR_NOT_AUTHENTICATED = nameof(VALIDATION_ERROR_NOT_AUTHENTICATED);
    public const string VALIDATION_ERROR_NOT_AUTHORIZED = nameof(VALIDATION_ERROR_NOT_AUTHORIZED);
    public const string VALIDATION_ERROR_NOT_VALID = nameof(VALIDATION_ERROR_NOT_VALID);
    public const string VALIDATION_ERROR_MUST_BE = nameof(VALIDATION_ERROR_MUST_BE);
    public const string VALIDATION_ERROR_MUST_NOT_BE = nameof(VALIDATION_ERROR_MUST_NOT_BE);
    public const string VALIDATION_ERROR_MUST_HAVE = nameof(VALIDATION_ERROR_MUST_HAVE);
    public const string VALIDATION_ERROR_MUST_HAVE_NOT = nameof(VALIDATION_ERROR_MUST_HAVE_NOT);
    public const string VALIDATION_ERROR_FORMAT_INCORRECT = nameof(VALIDATION_ERROR_FORMAT_INCORRECT);
    public const string VALIDATION_ERROR_FORM_VALUE_LESS_THAN_TO_VALUE = nameof(VALIDATION_ERROR_FORM_VALUE_LESS_THAN_TO_VALUE);
    public const string VALIDATION_ERROR_FORM_VALUE_GREATER_THAN_TO_VALUE = nameof(VALIDATION_ERROR_FORM_VALUE_GREATER_THAN_TO_VALUE);
    public const string VALIDATION_ERROR_REQUEST = nameof(VALIDATION_ERROR_REQUEST);
    public const string VALIDATION_INPUT_MODEL = nameof(VALIDATION_INPUT_MODEL);
    public const string NameDefault = nameof(NameDefault);
    public const string VALIDATION_ERROR_MUST_HAVE_BE_NUMBER = nameof(VALIDATION_ERROR_MUST_HAVE_BE_NUMBER);
    public const string VALIDATION_ERROR_MUST_HAVE_BE_NationalCode = nameof(VALIDATION_ERROR_MUST_HAVE_BE_NationalCode);
    public const string VALIDATION_ERROR_CAN_NOT_GET_TOKEN = nameof(VALIDATION_ERROR_CAN_NOT_GET_TOKEN);
    public const string THE_ONLY_ALLOWED_FORMATS_ARE_PDF_JPEG_AND_JPG = nameof(THE_ONLY_ALLOWED_FORMATS_ARE_PDF_JPEG_AND_JPG);
    public const string THE_ONLY_ALLOWED_FORMATS_ARE_PNG = nameof(THE_ONLY_ALLOWED_FORMATS_ARE_PNG);
    public const string THE_ONLY_ALLOWED_FORMATS_ARE_Exel = nameof(THE_ONLY_ALLOWED_FORMATS_ARE_Exel);
    public const string THE_SIGNATURE_NOT_VALID = nameof(THE_SIGNATURE_NOT_VALID);
    public const string THE_MAXIMUM_FILE_SIZE_IS_10_MB = nameof(THE_MAXIMUM_FILE_SIZE_IS_10_MB);
    public const string THE_MAXIMUM_FILE_SIZE_IS_5_MB = nameof(THE_MAXIMUM_FILE_SIZE_IS_5_MB);
    public const string PLEASE_ENTER_THE_FEE_AMOINT_FIRST = nameof(PLEASE_ENTER_THE_FEE_AMOINT_FIRST);
    public const string THE_OPERATION_WAS_NOT_SUCCESSFUL = nameof(THE_OPERATION_WAS_NOT_SUCCESSFUL);


    public const string VALIDATION_ERROR_FILE_GROUP_EXIST = nameof(VALIDATION_ERROR_FILE_GROUP_EXIST);
    public const string VALIDATION_ERROR_IMAGE_TYPE_EXIST = nameof(VALIDATION_ERROR_IMAGE_TYPE_EXIST);
    public const string VALIDATION_ERROR_DOC_TYPE_EXIST = nameof(VALIDATION_ERROR_DOC_TYPE_EXIST);
    public const string VALIDATION_ERROR_IMAGE_DOCUMENT_TYPE_EXIST = nameof(VALIDATION_ERROR_IMAGE_DOCUMENT_TYPE_EXIST);


    public const string VALIDATION_ERROR_VIDEO_TYPE_EXIST = nameof(VALIDATION_ERROR_VIDEO_TYPE_EXIST);

    #endregion

    #region Lab

    public const string VALIDATION_ERROR_THE_START_DATE_MUST_NOT_BE_GREATER_THAN_THE_END_DATE = nameof(VALIDATION_ERROR_THE_START_DATE_MUST_NOT_BE_GREATER_THAN_THE_END_DATE);
    public const string THE_CERTIFICATE_EXPIRATION_DATE_MUST_NOT_BE_LESS_THAN_THE_ESTABLISHMENT_DATE = nameof(THE_CERTIFICATE_EXPIRATION_DATE_MUST_NOT_BE_LESS_THAN_THE_ESTABLISHMENT_DATE);
    public const string THE_ESTABLISHMENT_DATE_SHOULD_NOT_BE_GREATER_THAN_TODAY_S_DATE = nameof(THE_ESTABLISHMENT_DATE_SHOULD_NOT_BE_GREATER_THAN_TODAY_S_DATE);
    public const string THE_CERTIFICATE_START_DATE_MUST_NOT_BE_LESS_THAN_THE_ESTABLISHMENT_DATE = nameof(THE_CERTIFICATE_START_DATE_MUST_NOT_BE_LESS_THAN_THE_ESTABLISHMENT_DATE);
    public const string VALIDATION_ERROR_THE_ENTERED_EMAIL_FORMAT_IS_NOT_CORRECT = nameof(VALIDATION_ERROR_THE_ENTERED_EMAIL_FORMAT_IS_NOT_CORRECT);
    public const string VALIDATION_ERROR_INVALID_FORMAT = nameof(VALIDATION_ERROR_INVALID_FORMAT);
    public const string THE_LABORATORY_WITH_IS_NOT_EXIST = nameof(THE_LABORATORY_WITH_IS_NOT_EXIST);
    public const string VALIDATION_ERROR_EXAMINATIONTYPE_IS_ALLOCATED = nameof(VALIDATION_ERROR_EXAMINATIONTYPE_IS_ALLOCATED);
    public const string VALIDATION_ERROR_EQUIPMENT_IS_ALLOCATED = nameof(VALIDATION_ERROR_EQUIPMENT_IS_ALLOCATED);
    public const string VALIDATION_ERROR_NOT_EXIST_TO_PARAMETER = nameof(VALIDATION_ERROR_NOT_EXIST_TO_PARAMETER);
    public const string Id = nameof(Id);
    public const string BusinessId = nameof(BusinessId);
    public const string Name = nameof(Name);
    public const string Location = nameof(Location);
   
    public const string Address = nameof(Address);
    public const string HSCode = nameof(HSCode);
    public const string PositionId = nameof(PositionId);
    public const string LicenceNO = nameof(LicenceNO);
    public const string LicenceStartDate = nameof(LicenceStartDate);
    public const string LicenceEndDate = nameof(LicenceEndDate);
    public const string TelNo = nameof(TelNo);
    public const string Email = nameof(Email);
    public const string SamplerAvailable = nameof(SamplerAvailable);
    public const string TransferAvailable = nameof(TransferAvailable);
    public const string ManagerInformation = nameof(ManagerInformation);
    public const string Active = nameof(Active);
    public const string Deleted = nameof(Deleted);
    public const string LastName = nameof(LastName);
    public const string PhoneNumber = nameof(PhoneNumber);
    public const string EmailAddress = nameof(EmailAddress);
    public const string Value = nameof(Value);
    public const string CreatedByUserId = nameof(CreatedByUserId);
    public const string CreatedDateTime = nameof(CreatedDateTime);
    public const string ModifiedByUserId = nameof(ModifiedByUserId);
    public const string ModifiedDateTime = nameof(ModifiedDateTime);
    public const string Title = nameof(Title);
    public const string NewRequest = nameof(NewRequest);
    public const string Pending = nameof(Pending);
    public const string Approved = nameof(Approved);
    public const string Rejected = nameof(Rejected);

    public const string NationalID = nameof(NationalID);
    public const string NationalId = nameof(NationalId);
    public const string EmployeeID = nameof(EmployeeID);
    public const string FirstName = nameof(FirstName);
    public const string EquipmentId = nameof(EquipmentId);
    public const string ExaminationTypeId = nameof(ExaminationTypeId);

    public const string ZipCode = nameof(ZipCode);
    public const string FieldOfActivity = nameof(FieldOfActivity);
    public const string CertificateID = nameof(CertificateID);
    public const string Latitude = nameof(Latitude);
    public const string Longitude = nameof(Longitude);
    public const string StablishmentDate = nameof(StablishmentDate);
    public const string CertificateValidityStartDate = nameof(CertificateValidityStartDate);
    public const string CertificateValidityEndDate = nameof(CertificateValidityEndDate);
    public const string LabRequested_PhoneNumber = nameof(LabRequested_PhoneNumber);
    public const string LabRequested_FullName = nameof(LabRequested_FullName);
    public const string Owner_FullName = nameof(Owner_FullName);
    public const string Owner_NationalId = nameof(Owner_NationalId);
    public const string Owner_NationalID = nameof(Owner_NationalID);
    public const string Owner_PhoneNumber = nameof(Owner_PhoneNumber);
    public const string INVALID_FORMAT_FOR_ACTIVITY_FIELD_RANGE = nameof(INVALID_FORMAT_FOR_ACTIVITY_FIELD_RANGE);
    public const string THE_EXEL_FILE_FORMAT_IS_INVALID= nameof(THE_EXEL_FILE_FORMAT_IS_INVALID);
    public const string VALIDATION_ERROR_NO_SCOPE_FOR_ACTIVITY = nameof(VALIDATION_ERROR_NO_SCOPE_FOR_ACTIVITY);


    public const string LabId = nameof(LabId);
    public const string labId = nameof(labId);
    public const string LabID = nameof(LabID);
    public const string EmployeeType = nameof(EmployeeType);
    public const string HsCodeExelFile = nameof(HsCodeExelFile);

    public const string EmployeeId = nameof(EmployeeId);
    public const string EmployeeProfileId = nameof(EmployeeProfileId);
    public const string EmployeeProfileID = nameof(EmployeeProfileID);
    public const string SeasonCode = nameof(SeasonCode);
    public const string PositionID = nameof(PositionID);
    public const string UserId = nameof(UserId);
    public const string ID = nameof(ID);
    public const string labType = nameof(labType);
    public const string LabType = nameof(LabType);

    public const string OwnerPhoneNumber = nameof(OwnerPhoneNumber);
    public const string ResultDescription = nameof(ResultDescription);
    public const string OwnerNationalID= nameof(OwnerNationalID);
    public const string THE_LABORATORY_WITH_THE_ENTERED_NATIONAL_ID_HAS_ALREADY_BEEN_REGISTERED_IN_THE_SYSTEM = nameof(THE_LABORATORY_WITH_THE_ENTERED_NATIONAL_ID_HAS_ALREADY_BEEN_REGISTERED_IN_THE_SYSTEM);
    public const string A_USER_WITH_THIS_NATIONAL_ID_AND_PHONE_NUMBER_ALREADY_EXISTS_IN_THIS_LABORATORY = nameof(A_USER_WITH_THIS_NATIONAL_ID_AND_PHONE_NUMBER_ALREADY_EXISTS_IN_THIS_LABORATORY);


    public const string OwnerLastName = nameof(OwnerLastName);
    public const string OwnerFirstName = nameof(OwnerFirstName);
    public const string LegalNationalId = nameof(LegalNationalId);
    public const string Owner_LastName = nameof(Owner_LastName);
    public const string Owner_FirstName = nameof(Owner_FirstName);
    public const string LabCode = nameof(LabCode);
    public const string documentTypeId = nameof(documentTypeId);
    public const string ProfileId = nameof(ProfileId);
    public const string There_Was_A_Problem_Removing_The_User_From_The_System = nameof(There_Was_A_Problem_Removing_The_User_From_The_System);
    public const string There_Was_A_Problem_Create_The_User_From_The_System = nameof(There_Was_A_Problem_Create_The_User_From_The_System);


    #endregion

    #region Request

    public const string CottageNumber = nameof(CottageNumber);
    public const string LaboratoryId = nameof(LaboratoryId);
    public const string RequestDate = nameof(RequestDate);
    public const string Description = nameof(Description);
    public const string DeclarationDate = nameof(DeclarationDate);
    public const string OwnerName = nameof(OwnerName);
    public const string OwnerMobileNumber = nameof(OwnerMobileNumber);
    public const string OwnerNationalId = nameof(OwnerNationalId);
    public const string Status = nameof(Status);
    public const string TariffCode = nameof(TariffCode);
    public const string BusinessDescription = nameof(BusinessDescription);
    public const string TariffDescription = nameof(TariffDescription);
    public const string CustomsAssessmentLocation = nameof(CustomsAssessmentLocation);
    public const string GoodsId = nameof(GoodsId);
    public const string WaitForCalculation = nameof(WaitForCalculation);
    public const string RegisteredFee = nameof(RegisteredFee);
    public const string WaitForPayment = nameof(WaitForPayment);
    public const string Paid = nameof(Paid);
    public const string WaitForInsertResult = nameof(WaitForInsertResult);
    public const string InsertAndEditResult = nameof(InsertAndEditResult);
    public const string EndOfRequst = nameof(EndOfRequst);

    public const string CahngeStatusNotValid = nameof(CahngeStatusNotValid);
    public const string VALIDATION_ERROR_MAXIMUM_VALUE = nameof(VALIDATION_ERROR_MAXIMUM_VALUE);


    public const string RequestId = nameof(RequestId);
    public const string RequestHistoryId = nameof(RequestHistoryId);
    public const string Request = nameof(Request);
    public const string request = nameof(request);
    public const string GoodsID = nameof(GoodsID);
    public const string RequestGoodsId = nameof(RequestGoodsId);


    #endregion

    #region RequestPeyment

    public const string Fee = nameof(Fee);
    public const string Amount = nameof(Amount);
    public const string Currency = nameof(Currency);

    #endregion

    #region RequestResult

    public const string FileContent = nameof(FileContent);
    public const string RequestID = nameof(RequestID);
    public const string Key = nameof(Key);
    public const string Content = nameof(Content);
    public const string CANNOT_SET_STATUS_TO_REGISTEREDFEE_FEEAMOUNT_MUST_BE_GREATER_THEN_0 = nameof(CANNOT_SET_STATUS_TO_REGISTEREDFEE_FEEAMOUNT_MUST_BE_GREATER_THEN_0);
    public const string CANNOT_SET_STATUS_TO_INSERTRESULT_FILECONTENT_CANNOT_BE_NULL = nameof(CANNOT_SET_STATUS_TO_INSERTRESULT_FILECONTENT_CANNOT_BE_NULL);
    public const string CANNOT_SET_STATUS_TO_INSERTRESULT_RESULTDESCRIPTION_CANNOT_BE_NULL_OR_EMPTY = nameof(CANNOT_SET_STATUS_TO_INSERTRESULT_RESULTDESCRIPTION_CANNOT_BE_NULL_OR_EMPTY);
    public const string CANNOT_TRANSITION_FROM_CURRENT_TO_NEXT_STATUS = nameof(CANNOT_TRANSITION_FROM_CURRENT_TO_NEXT_STATUS);
    public const string CANNOT_SET_FEE_ON_THIS_CURRENT_STATUS = nameof(CANNOT_SET_FEE_ON_THIS_CURRENT_STATUS);
    public const string CHANGING_THE_STATUS_IS_NOT_POSSIBLE_AT_THIS_STAGE = nameof(CHANGING_THE_STATUS_IS_NOT_POSSIBLE_AT_THIS_STAGE);
    public const string IT_IS_NOT_POSSIBLE_TO_INSERT_RESULT_AT_THIS_STAGE = nameof(IT_IS_NOT_POSSIBLE_TO_INSERT_RESULT_AT_THIS_STAGE);
    public const string IT_IS_NOT_POSSIBLE_TO_EXPECTED_DATE_AT_THIS_STAGE = nameof(IT_IS_NOT_POSSIBLE_TO_EXPECTED_DATE_AT_THIS_STAGE);
    public const string FILE_DELETION_IS_NOT_POSSIBLE_AT_THIS_STAGE = nameof(FILE_DELETION_IS_NOT_POSSIBLE_AT_THIS_STAGE);
    public const string FILE_UPLOADING_IS_NOT_POSSIBLE_AT_THIS_STAGE = nameof(FILE_UPLOADING_IS_NOT_POSSIBLE_AT_THIS_STAGE);
    public const string THE_ENTERED_DATE_CANNOT_BE_YOUNGER_THAN_TODAYS_DATE = nameof(THE_ENTERED_DATE_CANNOT_BE_YOUNGER_THAN_TODAYS_DATE);


    #endregion

    #region LabProfile & LabMember

    public const string Owner = nameof(Owner);
    public const string Lastname = nameof(Lastname);
    public const string Firsname = nameof(Firsname);
    public const string ActivityScope = nameof(ActivityScope);
    public const string ActivityField = nameof(ActivityField);
    public const string TechnicalManager = nameof(TechnicalManager);

    #endregion

    #region Logs

    #region Handler Messages

    public const string HANDLER_RUN_LOG = nameof(HANDLER_RUN_LOG);
    public const string HANDLER_COMPLETE_OPERATION_LOG = nameof(HANDLER_COMPLETE_OPERATION_LOG);
    public const string HANDLER_CATCH_EXCEPTION_LOG = nameof(HANDLER_CATCH_EXCEPTION_LOG);
    public const string HANDLER_READ_QUERY_LOG = nameof(HANDLER_READ_QUERY_LOG);

    #endregion

    #endregion

    #region FileManagement

    public const string THE_MINIMUM_SIZE_SELECTED_MUST_BE = nameof(THE_MINIMUM_SIZE_SELECTED_MUST_BE);
    public const string THE_MAXIMUM_SIZE_SELECTED_MUST_BE = nameof(THE_MAXIMUM_SIZE_SELECTED_MUST_BE);
    public const string FILE_GROUP_IS_NOT_SUPPORTED = nameof(FILE_GROUP_IS_NOT_SUPPORTED);

    public const string MinSize = nameof(MinSize);
    public const string MaxSize = nameof(MaxSize);
    public const string ImageType = nameof(ImageType);
    public const string DocType = nameof(DocType);
    public const string VideoType = nameof(VideoType);
    public const string File = nameof(File);
    public const string DocumentFileId = nameof(DocumentFileId);


    #endregion

    #region SamtLaboratory

    public const string THE_DESIRED_ITEM_EXISTS = nameof(THE_DESIRED_ITEM_EXISTS);
    

    #endregion
    #endregion


    #region Season

    public const string VALIDATION_ERROR_NOT_LAB_EXIST = nameof(VALIDATION_ERROR_NOT_LAB_EXIST);


    public const string DocumentCategoryId = nameof(DocumentCategoryId);
    public const string DocumentTypeId = nameof(DocumentTypeId);
    public const string HsCodeExel = nameof(HsCodeExel);

    #endregion
}