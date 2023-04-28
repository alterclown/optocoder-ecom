namespace OptoCoderEcommerceApi.Data.Utilities
{
    public class Enums
    {
        public enum Status
        {
            Active = 1,
            Inactive = 2,
            Deleted = 3,
        }

        public enum UserType
        {
            Admin = 1,
            Dispatch = 2,
            GarmentOwner = 3,
            TruckOwner = 4
        }

        public enum DeviceStatus
        {
            Active = 1,
            Assigned = 2,
            Released = 3,
            Deleted = 4
        }

        public enum ModelStatus
        {
            Already = -1,
            SystemError = -2,
            InvalidParameter = -3,
            Inserted = 1,
            Updated = 2,
            Deleted = 3
        }

        public enum ResponseCode
        {
            Success = 200,
            InternalServerError = 500,
            Failed = 404,
            Warning = 400,
            UnAuthorize = 401,
        }

        public enum ResponseMessageType
        {
            Success = 1,
            Warning = 2,
            Error = 3,
            Notification = 4
        }
        public enum RegistrationStatus
        {
            Request = 1,
            OTPSent = 2,
            PhoneNoConfirmed = 3,
            Registered = 4
        }
        public enum StatusOfAlive
        {
            Online = 1,
            Offline = 2,
            Away = 3,
            Busy = 4,
            StandBy = 5,
            Custom = 6
        }
        public enum Role
        {
            SuperAdmin = 1,
            CompanyAdmin = 2,
            Agent = 3,
            Participant = 4
        }

        public enum PickType
        {
            Accepted = 1,
            Rejected = 2
        }

        public enum ExceptionType
        {
            Log = 1,
            Exception = 2,
        }

        public enum ValidationType
        {
            IsNullOrEmpty = 1,
            IsNullOrWhiteSpace = 2,
            IsLessThanThree = 3,
            IsLessThanOrEqual = 4,
            IsGreaterThan = 5,
            IsGreaterThanOrEqual = 6,
            IsEqual = 7,
            IsNotEqual = 8,
            IsValidEmail = 9,
            IsNull = 10,
            IsDuplicateItem = 11,
            IsLengthLessThan = 12,
            IsGreaterThanFifty = 13,
            IsPositiveIntegreOrNull = 14,
            IsValidDate = 15
        }

        public enum RequisitionStatus
        {
            Pending = 1,
            Cancel = 2,
            Approved = 3,
            Reject = 4
        }

        public enum TripStatus
        {
            ReadyToStart = 1,
            Running = 2,
            Completed = 3
        }

        public enum HistoryStatus
        {
            Running = 1,
            Completed = 2,

        }

        public enum TripNewStatus
        {
            Pending = 1,
            Running = 2,
            Completed = 3,

        }

        #region "Exception Log"

        public enum ExceptionModule
        {
            AdminPanel = 1,
            App = 2,
            Sentra = 3
        }

        public enum ActionName
        {
            User = 1,
            Dashboard = 2
        }

        public enum ActionType
        {
            Add = 1,
            Update = 2,
            Delete = 3,
            filter = 4,
            View = 5,
            List = 6
        }

        public enum LogFixPriority
        {
            Low = 1,
            Medium = 2,
            High = 3
        }
        public enum WebSocketType
        {
            Low = 1,
            Medium = 2,
        }

        #endregion        
    }
}
