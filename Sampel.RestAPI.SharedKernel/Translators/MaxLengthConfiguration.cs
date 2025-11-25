namespace Sampel.RestAPI.SharedKernel.Translators;
public class MaxLengthConfiguration
{
    #region LAB

    public const byte NAME_MAXLENGTHS = 250;
    public const short LOCATION_MAXLENGTHS = 500;
    public const short ADDRESS_MAXLENGTHS = 1000;
    public const byte HSCODE_MAXLENGTHS = 50;
    public const byte LICENCE_NO_MAXLENGTHS = 50;
    public const byte TEL_NO_MAXLENGTHS = 15;
    public const short EMAIL_MAXLENGTHS = 320;
    public const byte MANAGER_NAME_MAXLENGTHS = 100;
    public const byte MANAGER_LAST_NAME_MAXLENGTHS = 100;
    public const byte NATIONAL_ID_MAXLENGTHS = 10;
    public const byte OWNER_NATIONAL_ID_MINLENGTHS = 10;
    public const byte OWNER_NATIONAL_ID_MAXLENGTHS = 10;
    public const byte LEGAL_NATIONAL_ID_MAXLENGTHS = 11;
    public const byte NAME_MINLENGTHS = 2;
    public const byte LOCATION_MINLENGTHS = 2;
    public const byte ADDRESS_MINLENGTHS = 2;
    public const byte HSCODE_MINLENGTHS = 2;
    public const byte LICENCE_NO_MINLENGTHS = 2;
    public const byte TEL_NO_MINLENGTHS = 6;
    public const byte MOBILEL_NO_MINLENGTHS = 11;
    public const byte EMAIL_MINLENGTHS = 2;
    public const byte MANAGER_LAST_NAME_MINLENGTHS = 2;
    public const byte POSITION_NAME_MAXLENGTH = 50;
    #endregion

    #region Request

    public const short DESCRIPTION_REQUEST_MAXLENGTH = 3000;
    public const short DESCRIPTION_REQUEST_MINLENGTH = 3;
    public const short DESCRIPTION_MAXLENGTH = 500;
    public const byte CHANGED_BY_MAXLENGTH = 50;
    public const byte COTTAGE_NUMBER_MAXLENGTH = 20;
    public const short REQUEST_DESCRIPTION_MAXLENGTH = 3000;
    public const short REQUEST_DESCRIPTION_MINLENGTH = 2;
    public const short RESUALT_DESCRIPTION_MAXLENGTH = 3000;
    public const short RESUALT_DESCRIPTION_MINLENGTH = 2;
    public const short NAME_MAXLENGTH = 100;
    public const short FILE_NAME_MAXLENGTH = 100;
    public const short FILE_NAME_MINLENGTH = 2;
    public const short HC_GOODS_UNIT_TYPE_CODE_MAXLENGTH = 20;
    public const short HC_GOODS_UNIT_TYPE_NAME_MAXLENGTH = 20;
    public const short HC_GOODS_UNIT_TYPE_NAME_MINLENGTH = 2;
    public const short FILE_CONTENT_MAXLENGTH = 100;
    public const short FILE_CONTENT_MINLENGTH = 2;
    public const short PRODUTION_YEAR_MAXLENGTH = 4;
    public const short PRODUTION_COMOANY_MAXLENGTH = 50;
    public const short DESCRIPTION_MINLENGTH = 2;
    public const byte OWNER_MOBILE_NUMBER = 15;
    public const byte OWNER_NAME_MAXLENGTHS = 100;
    public const byte OWNER_NAME_MINLENGTHS = 2;
    public const byte DECLARARION_TYPE_NAME_MAXLENGTHS = 100;
    public const int MAXIMUM_AMOUNT = 1000000000;



    #region Request Goods
    public const short GOODS_TITLE_MAXLENGTHS = 400;
    public const short GoodsID_MAXLENGTHS = 50;
    public const short DECLARATION_GOODS_TITLE_MAXLENGTHS = 400;
    public const byte DECLARATION_GOODS_TITLE_MINLENGTHS = 2;
    public const byte COMMERCIAL_DESCRIPTION_MAXLENGTHS = 200;
    public const byte CURRENCY_MAXLENGTHS = 5;
    public const byte HS_CODE_MAXLENGTHS = 8;
    public const byte HS_CODE_MINLENGTHS = 8;
    public const byte HS_CODE_DESCRIPTION_MAXLENGTHS = 200;
    public const byte HS_CODE_DESCRIPTION_MINLENGTHS = 2;
    public const byte HC_GOODS_UNIT_TYPE_NAME_MAXLENGTHS = 20;
    public const byte PRODUTION_YEAR_MAXLENGTHS = 4;
    public const byte PRODUTION_COMPANY_MAXLENGTHS = 50;
    public const byte PRODUTION_COMPANY_MINLENGTHS = 2;

    #endregion

    #region Status

    public const byte STATUS_NAME_MIN_LENGTH = 2;
    public const byte STATUS_NAME_MAX_LENGTH = 25;
    public const byte STATUS_CONDITIONS_MAX_LENGTH = 25;

    #endregion

    #region Goods Status Histories
    public const byte NEW_STATUS_MAX_LENGTH = 20;
    public const byte OLD_STATUS_MAX_LENGTH = 20;
    public const byte CREATEF_BY_MAX_LENGTH = 100;
    public const byte ChANGED_BY_MAX_LENGTH = 100;
    public const byte ChANGED_BY_MIN_LENGTH = 2;

    #endregion

    #region Customs

    public const byte CUSTOMS_CODE = 100;
    public const byte CUSTOMS_LOCATION_NAME_MAXLENGTHS = 100;
    public const byte CUSTOMS_LOCATION_NAME_MINLENGTHS = 2;
    public const byte CUSTOMS_LOCATION_ADDRESS_MAXLENGTHS = 100;
    public const byte CUSTOMS_LOCATION_ADDRESS_MINLENGTHS = 2;
    public const byte CUSTOMS_LOCATION_CITY_MAXLENGTHS = 50;
    public const byte CUSTOMS_LOCATION_CITY_MINLENGTHS = 2;
    public const byte CUSTOMS_LOCATION_CONTACT_INFO_MAXLENGTHS = 50;
    public const byte CUSTOMS_LOCATION_CONTACT_INFO_MINLENGTHS = 2;

    #endregion

    #region Fee Payment Info

    public const byte AGEBR_BANK_MAXLENGTHS = 50;
    public const byte AGEBR_BANK_MINLENGTHS = 2;
    public const byte PAYMENT_DESCRIPTION_MAXLENGTHS = 100;
    public const byte PAYMENT_DESCRIPTION_MINLENGTHS = 2;

    #endregion

    #region RequestPeyment
    public const byte AGENT_BANK_MAXLENGTHS = 50;
    public const byte PAID_BY_MAXLENGTHS = 100;
    public const byte PAYMENR_STATUS_MAXLENGTHS = 20;
    public const byte PAYMENR_DESCRIPTION_MAXLENGTHS = 100;

    #endregion

    #region Request Status Histories
    public const byte OLD_STATUS_MAXLENGTHS = 20;
    public const byte NEW_STATUS_MAXLENGTHS = 20;
    public const byte CREATED_BY_MAXLENGTHS = 100;

    #endregion

    #region LabEmployeeProfile & LabHsCode & Position

    public const byte HSCODE_DESCRIPTION_MAXLENGTHS = 100;
    public const short EMAIL_LAB_MAXLENGTHS = 100;
    public const short ADDRESS_LAB_MAXLENGTHS = 200;
    public const byte NAME_LAB_MAXLENGTHS = 100;
    public const byte OWNER_MAXLENGTHS = 100;
    public const byte PHOTOLOGO_MAXLENGTHS = 100;
    public const byte PHOTOLOGO_MINLENGTHS = 2;
    public const byte LASTNAME_MAXLENGTHS = 50;
    public const byte LASTNAME_MINLENGTHS = 2;
    public const byte FIRSTNAME_MINLENGTHS = 2;
    public const byte FIRSTNAME_MAXLENGTHS = 50;
    public const byte OWNER_MINLENGTHS = 2;
    public const byte NAME_REQUESTHISTORY = 50;
    public const byte ACTIVITY_SCOPE_MINLENGTHS = 2;
    public const byte ACTIVITY_SCOPE_MAXLENGTHS = 100;
    public const byte ACTIVITY_FIELD_MAXLENGTHS = 100;
    public const byte ACTIVITY_FIELD_MINLENGTHS = 2;
    public const byte TECHNICAL_MANAGER_MINLENGTHS = 2;
    public const byte TECHNICAL_MANAGER_MAXLENGTHS = 50;
    public const byte CERTIFICAT_ID_MAXLENGTHS = 50;
    public const byte CERTIFICAT_ID_MINLENGTHS = 2;
    public const byte NATIONAL_ID_MINLENGTHS = 11;
    public const byte NATIONAL_FOR_ID_MINLENGTHS = 10;
    public const byte ZIP_CODE_MAXLENGTHS = 10;
    public const byte ZIP_CODE_MINLENGTHS = 2;
    public const byte LATITUDE_MAXLENGTHS = 50;
    public const byte LONGITUDE_MAXLENGTHS = 50;
    public const byte SABPLER_AVAILABLE_MAXLENGTHS = 50;
    public const byte POSITION_NAME_MAXLENGTHS = 50;
    public const byte POSITION_NAME_MINLENGTHS = 2;
    public const byte SSO_USER_ID_MINLENGTHS = 2;
    public const byte POSITION_ID_MINLENGTHS = 20;
    public const byte LAB_ID_MINLENGTHS = 20;
    public const byte LOGO_NAME_MAXLENGTHS = 100;
    public const byte LOGO_NAME_MINLENGTHS = 2;
    public const byte LOGO_KEY_MAXLENGTHS = 100;
    public const byte LOGO_KEY_MINLENGTHS = 2;
    public const byte LOGO_CONTENT_MAXLENGTHS = 100;
    public const byte LOGO_CONTENT_MINLENGTHS = 2;
    public const byte PHONE_NUMBER_MAXLENGTHS = 11;
    public const byte PHONE_NUMBER_MINLENGTHS = 11;

    #endregion


    #region Lab Equipment

    public const byte TITEL_MAXLENGTHS = 100;
    public const byte TITEL_MINLENGTHS = 3;


    #endregion


    #region Document Category



    #endregion


    #region Season

    public const byte SASSON_CODE_MAXLENGTHS = 2;
    public const short SASSON_DESCRIPTION_MAXLENGTHS = 500;

    #endregion


    #region SamtLaboratory
    public const short SAMT_LABOEATORY_TITLE_MAXLENGTHS = 250;

    #endregion
    #endregion
}
