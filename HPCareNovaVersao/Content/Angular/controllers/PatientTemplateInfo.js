
app.controller("PatientTemplateInfo", function ($scope, PatientTemplateInformationFactory) {

    $scope.FamilyHistoryCategories = null;
    $scope.RiskFactorsCategories = null;
    $scope.AllergyCategories = null;
    $scope.PatientFamilyHistoryCategories = null;
    $scope.PatientRiskFactorsCategories = null;
    $scope.PatientAllergyCategories = null;
    $scope.PatientFullInformation = null;
    $scope.gender = null;
    $scope.MaritalStatus = null;


    $scope.Init = function () {
        var familyHistories = PatientTemplateInformationFactory.GetPatientFamilyHistories();
        familyHistories.then(function (dt) {
            $scope.PatientFamilyHistoryCategories = dt.data;
        }, function (error) {
            alert("erro");
        });

        var riskFactors = PatientTemplateInformationFactory.GetPatientRiskFactors();
        riskFactors.then(function (dt) {
            $scope.PatientRiskFactorsCategories = dt.data;
        }, function (error) {
            alert("erro");
        });

        var allergies = PatientTemplateInformationFactory.GetPatientAllergies();
        allergies.then(function (dt) {
            $scope.PatientAllergyCategories = dt.data;
        }, function (error) {
            alert("erro");
        });

        var patientInformation = PatientTemplateInformationFactory.GetPatientFullInformations();
        patientInformation.then(function (dt) {
            $scope.PatientFullInformation = dt.data;
            $scope.InitInformation();
        }, function (error) {
            alert("erro");
        });

    }

    $scope.InitInformation = function () {
        $scope.Name = $scope.PatientFullInformation[0].Name;
        $scope.Gender = $scope.PatientFullInformation[0].gender;
        $scope.MaritalStatus = $scope.PatientFullInformation[0].MaritalStatus;
        $scope.Address = $scope.PatientFullInformation[0].Address;
        $scope.Email = $scope.PatientFullInformation[0].Email;
        $scope.Telephone = $scope.PatientFullInformation[0].Telephone;
        $scope.Identification = $scope.PatientFullInformation[0].User_identification;
    }

});



app.factory('PatientTemplateInformationFactory', function ($http) {
    var fac = {};

    fac.GetPatientAllergies = function () {
        return $http.get('../Patient/GetPatientTemplateAllergies');
    }

    fac.GetPatientRiskFactors = function () {
        return $http.get('../Patient/GetPatientTemplateRisks');
    }

    fac.GetPatientFamilyHistories = function () {
        return $http.get('../Patient/GetPatientTemplateFamilyHistory');
    }

    fac.GetPatientFullInformations = function () {
        return $http.get('../Patient/GetPatientTemplateInformation');
    }

    return fac;
});

