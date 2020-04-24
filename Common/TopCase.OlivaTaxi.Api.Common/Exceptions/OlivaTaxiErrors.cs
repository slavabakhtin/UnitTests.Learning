namespace TopCase.OlivaTaxi.Api.Common.Exceptions
{
    public static class OlivaTaxiErrors
    {
        public enum StatusCodes
        {
            FirebaseUserNotFoundInDatabase = 5001,
            RequiredCacheValueIsMissing = 5002
        }

        public static class Internal
        {
            public static OlivaTaxiInternalServerError FirebaseUserNotFoundInDatabase =>
                new OlivaTaxiInternalServerError(StatusCodes.FirebaseUserNotFoundInDatabase, nameof(FirebaseUserNotFoundInDatabase));

            public static OlivaTaxiInternalServerError RequiredCacheValueIsMissing<TCache, TKey>(TCache cache, TKey key) =>
                new OlivaTaxiInternalServerError(StatusCodes.RequiredCacheValueIsMissing, nameof(RequiredCacheValueIsMissing),
                    $"Required value for key={key.ToString()} is not found in the cache {cache.GetType().Name}");
        }

        public static class BadRequest
        {
            public static OlivaTaxiBadRequestError DriverProfileNotFound(int driverId) => new OlivaTaxiBadRequestError(4000, nameof(DriverProfileNotFound), $"Driver with id {driverId} not found");

            public static OlivaTaxiBadRequestError CantCreateFirebaseAccount(string details) => new OlivaTaxiBadRequestError(4001, nameof(CantCreateFirebaseAccount), details);

            public static OlivaTaxiBadRequestError CostNotCalculated(string details) => new OlivaTaxiBadRequestError(4002, nameof(CostNotCalculated), details);

            public static OlivaTaxiBadRequestError FavoriteCalculationParamsNotFound(string details) => new OlivaTaxiBadRequestError(4003, nameof(FavoriteCalculationParamsNotFound), details);

            public static OlivaTaxiBadRequestError FavoriteOptionNotFound(string details) => new OlivaTaxiBadRequestError(4004, nameof(FavoriteOptionNotFound), details);

            public static OlivaTaxiBadRequestError AutoLicenseAlreadyExists => new OlivaTaxiBadRequestError(4005, nameof(AutoLicenseAlreadyExists));

            public static OlivaTaxiBadRequestError FavoriteClassNotFound(string details) => new OlivaTaxiBadRequestError(4006, nameof(FavoriteClassNotFound), details);

            public static OlivaTaxiBadRequestError DefaultCalculationParamsNotFound(string details) => new OlivaTaxiBadRequestError(4007, nameof(DefaultCalculationParamsNotFound), details);

            public static OlivaTaxiBadRequestError NeedBaggageAssistanceOptionNotFound => new OlivaTaxiBadRequestError(4008, nameof(NeedBaggageAssistanceOptionNotFound));

            public static OlivaTaxiBadRequestError NeedBabyChairOptionNotFound => new OlivaTaxiBadRequestError(4009, nameof(NeedBabyChairOptionNotFound));

            public static OlivaTaxiBadRequestError ParkAccountMustBeSpecified => new OlivaTaxiBadRequestError(4010, nameof(ParkAccountMustBeSpecified));

            public static OlivaTaxiBadRequestError CostCalculationExpired(string details) => new OlivaTaxiBadRequestError(4011, nameof(CostCalculationExpired), details);

            public static OlivaTaxiBadRequestError ClassOptionIsNotAvailable(string details) => new OlivaTaxiBadRequestError(4012, nameof(ClassOptionIsNotAvailable), details);

            public static OlivaTaxiBadRequestError DriverHasNoCarAssigned(string firebaseAccountId) => new OlivaTaxiBadRequestError(4013, nameof(DriverHasNoCarAssigned), $"A car is not assigned to current driver FirebaseID={firebaseAccountId}."); 

            public static OlivaTaxiBadRequestError AccountIsAlreadyActiveInTheSpecifiedPark => new OlivaTaxiBadRequestError(4014, nameof(AccountIsAlreadyActiveInTheSpecifiedPark));

            public static OlivaTaxiBadRequestError CarAlreadyAssignedToSpecifiedDriver => new OlivaTaxiBadRequestError(4015, nameof(CarAlreadyAssignedToSpecifiedDriver));

            public static OlivaTaxiBadRequestError FreePlace11 => new OlivaTaxiBadRequestError(4016, nameof(FreePlace11));

            public static OlivaTaxiBadRequestError CantDeactivateDriver(string details) => new OlivaTaxiBadRequestError(4017, nameof(CantDeactivateDriver), details);

            public static OlivaTaxiBadRequestError InvalidPhotoUrl => new OlivaTaxiBadRequestError(4018, nameof(InvalidPhotoUrl));

            public static OlivaTaxiBadRequestError ProfileNotFound(string details) => new OlivaTaxiBadRequestError(4019, nameof(ProfileNotFound), details);

            public static OlivaTaxiBadRequestError InvalidPageValue(string details) => new OlivaTaxiBadRequestError(4020, nameof(InvalidPageValue), details);

            public static OlivaTaxiBadRequestError InvalidCountValue(string details) => new OlivaTaxiBadRequestError(4021, nameof(InvalidCountValue), details);

            public static OlivaTaxiBadRequestError CantDeleteFirebaseAccount(string details) => new OlivaTaxiBadRequestError(4022, nameof(CantDeleteFirebaseAccount), details);

            public static OlivaTaxiBadRequestError InvalidCarParkAccountStatus(string details) => new OlivaTaxiBadRequestError(4023, nameof(InvalidCarParkAccountStatus), details);

            public static OlivaTaxiBadRequestError TripIsPaused => new OlivaTaxiBadRequestError(4024, nameof(TripIsPaused));
          
            public static OlivaTaxiBadRequestError RolesAreEmpty => new OlivaTaxiBadRequestError(4025, nameof(RolesAreEmpty));

            public static OlivaTaxiBadRequestError ParkNotFound(string details) => new OlivaTaxiBadRequestError(4026, nameof(ParkNotFound), details);

            public static OlivaTaxiBadRequestError BrandNotFound(string details) => new OlivaTaxiBadRequestError(4027, nameof(BrandNotFound), details);

            public static OlivaTaxiBadRequestError ModelNotFound(string details) => new OlivaTaxiBadRequestError(4029, nameof(ModelNotFound), details);
            
            public static OlivaTaxiBadRequestError ColorNotFound(string details) => new OlivaTaxiBadRequestError(4030, nameof(ColorNotFound), details);

            public static OlivaTaxiBadRequestError ClassNotFound(string details) => new OlivaTaxiBadRequestError(4031, nameof(ClassNotFound), details);

            public static OlivaTaxiBadRequestError FreePlace12 => new OlivaTaxiBadRequestError(4032, nameof(FreePlace12));

            public static OlivaTaxiBadRequestError CantCancelTrip(string details) => new OlivaTaxiBadRequestError(4033, nameof(CantCancelTrip), details);
            
            public static OlivaTaxiBadRequestError CarNotFound => new OlivaTaxiBadRequestError(4034, nameof(CarNotFound));

            public static OlivaTaxiBadRequestError AccountIsBlocked(string details) => new OlivaTaxiBadRequestError(4035, nameof(AccountIsBlocked), details);

            public static OlivaTaxiBadRequestError AccountNotConfirmed(string details) => new OlivaTaxiBadRequestError(4036, nameof(AccountNotConfirmed), details);

            public static OlivaTaxiBadRequestError CancelReasonAlreadySet => new OlivaTaxiBadRequestError(4037, nameof(CancelReasonAlreadySet));

            public static OlivaTaxiBadRequestError NotAllDataSet => new OlivaTaxiBadRequestError(4038, nameof(NotAllDataSet));

            public static OlivaTaxiBadRequestError DriverHistoryNotFound(string details) => new OlivaTaxiBadRequestError(4039, nameof(DriverHistoryNotFound), details);
            
            public static OlivaTaxiBadRequestError StatusNotDraft(string details) => new OlivaTaxiBadRequestError(4040, nameof(StatusNotDraft), details);
            
            public static OlivaTaxiBadRequestError AreaNotFound(string details) => new OlivaTaxiBadRequestError(4041, nameof(AreaNotFound), details);
           
            public static OlivaTaxiBadRequestError FreePlace5 => new OlivaTaxiBadRequestError(4042, nameof(FreePlace5));

            public static OlivaTaxiBadRequestError RatingNotMatched(string details) => new OlivaTaxiBadRequestError(4043, nameof(RatingNotMatched), details);
            
            public static OlivaTaxiBadRequestError FreePlace6 => new OlivaTaxiBadRequestError(4044, nameof(FreePlace6));

            public static OlivaTaxiBadRequestError InvalidOrderStatus(string details) => new OlivaTaxiBadRequestError(4045, nameof(InvalidOrderStatus), details);

            public static OlivaTaxiBadRequestError AccountIsActiveInAnotherPark => new OlivaTaxiBadRequestError(4046, nameof(AccountIsActiveInAnotherPark));
            
            public static OlivaTaxiBadRequestError CurrentDriverOrderNotFound(string details) => new OlivaTaxiBadRequestError(4047, nameof(CurrentDriverOrderNotFound), details);

            public static OlivaTaxiBadRequestError CantGetFirebaseAccount(string firebaseId) => new OlivaTaxiBadRequestError(4048, nameof(CantGetFirebaseAccount), $"Firebase account with ID={firebaseId} not found");

            public static OlivaTaxiBadRequestError InvalidOrderByValue(string details) => new OlivaTaxiBadRequestError(4049, nameof(InvalidOrderByValue), details);
            
            public static OlivaTaxiBadRequestError FreePlace7 => new OlivaTaxiBadRequestError(4050, nameof(FreePlace7));
            
            public static OlivaTaxiBadRequestError PhoneAlreadyExists(string details) => new OlivaTaxiBadRequestError(4051, nameof(PhoneAlreadyExists), details);
            
            public static OlivaTaxiBadRequestError EmailAlreadyExists(string details) => new OlivaTaxiBadRequestError(4052, nameof(EmailAlreadyExists), details);
          
            public static OlivaTaxiBadRequestError CantUpdateFirebaseAccount(string details) => new OlivaTaxiBadRequestError(4053, nameof(CantUpdateFirebaseAccount), details);

            public static OlivaTaxiBadRequestError FreePlace8 => new OlivaTaxiBadRequestError(4054, nameof(FreePlace8));
            
            public static OlivaTaxiBadRequestError CarIsOccupiedByAnotherDriver => new OlivaTaxiBadRequestError(4055, nameof(CarIsOccupiedByAnotherDriver));
            
            public static OlivaTaxiBadRequestError FreePlace9 => new OlivaTaxiBadRequestError(4056, nameof(FreePlace9));
            
            public static OlivaTaxiBadRequestError IncorrectLevelValue => new OlivaTaxiBadRequestError(4057, nameof(IncorrectLevelValue));
            
            public static OlivaTaxiBadRequestError UnsupportedArea => new OlivaTaxiBadRequestError(4058, nameof(UnsupportedArea));
            
            public static OlivaTaxiBadRequestError TicketCategoryNotFound => new OlivaTaxiBadRequestError(4059, nameof(TicketCategoryNotFound));

            public static OlivaTaxiBadRequestError CarBelongsToAnotherPark(int carId, int carCarParkId, int accountParkId) => new OlivaTaxiBadRequestError(4060, nameof(CarBelongsToAnotherPark), $"Car with ID={carId} assigned to park ID={carCarParkId} which differs account's park (ID={accountParkId}).");

            public static OlivaTaxiBadRequestError ParentZoneNotFound => new OlivaTaxiBadRequestError(4061, nameof(ParentZoneNotFound));

            public static OlivaTaxiBadRequestError RolesAreMissingOrInvalid => new OlivaTaxiBadRequestError(4062, nameof(RolesAreMissingOrInvalid));
        }
    }
}