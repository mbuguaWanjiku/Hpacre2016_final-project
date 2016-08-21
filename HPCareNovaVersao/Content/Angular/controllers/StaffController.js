var staffDetails = [];
app.controller("StaffInformationsController", function ($scope, StaffInformationFactory, alert) {
 
    $scope.StaffFullInformation = null;
    $scope.Staff = null;
    
    $scope.Init = function () {

        var staffInformation = StaffInformationFactory.GetStaffFullInformations();
        staffInformation.then(function (dt) {
            $scope.StaffFullInformation = dt.data;
            
            $scope.InitInformation();
        }, function (error) {
            alert.warning("Error in getting the information !");
        });

    }

    $scope.InitInformation = function () {
        $scope.Name = $scope.StaffFullInformation[0].Name;
        $scope.Gender = $scope.StaffFullInformation[0].gender;
        $scope.MaritalStatus = $scope.StaffFullInformation[0].MaritalStatus;
        $scope.Address = $scope.StaffFullInformation[0].Address;
        $scope.Email = $scope.StaffFullInformation[0].Email;
        $scope.Telephone = $scope.StaffFullInformation[0].Telephone;
        $scope.Identification = $scope.StaffFullInformation[0].User_identification;
        $scope.ProfessionalType = $scope.StaffFullInformation[0].ProfessionalType;
    }

    $scope.SaveInformation = function(){
        var Staff = new Object();
        Staff.Name = $scope.Staff.Name;
        Staff.gender = $scope.Staff.gender;
        Staff.MaritalStatus = $scope.Staff.MaritalStatus;
        Staff.Address = $scope.Staff.Address;
        Staff.Email = $scope.Staff.Email;
        Staff.Telephone = $scope.Staff.Telephone;

        staffDetails.push(Staff);
        if (staffDetails.length > 0) {
            var getData = StaffInformationFactory.saveStaffInformations(staffDetails);
            getData.then(function (message) {
                alert.success("Patient info added with success !");
                staffDetails = [];
            }, function () {
                alert.warning("Something went wrong ! Please try again. ");
            });
        }

    }

});



app.factory('StaffInformationFactory', function ($http) {
    var fac = {};

    fac.GetStaffFullInformations = function () {
        return $http.get('../Staffs/GetStaffInformation');
    }

    fac.saveStaffInformations = function (listInformations) {
        var informations = JSON.stringify({ 'staffInformations': staffDetails });
        var response = $http({
            method: "post",
            url: "../Staffs/SaveStaffInformations",
            data: informations,
            dataType: "json",
        });
        return response;
    }

    return fac;
});

