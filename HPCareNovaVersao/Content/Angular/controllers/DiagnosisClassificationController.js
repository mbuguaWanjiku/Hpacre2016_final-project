var CIDclassificationVW = [];
var CIDclassificationDB = [];
app.controller("DiagnosisController", function ($scope, $interval, DiagnosisService) {
    $scope.CidCode = null;
    $scope.category = null;
    $scope.CIDclassificationBuffer = [];
    $interval(function () {
        $scope.CIDclassificationBuffer = CIDclassificationVW;
    }, 500);


    // Populate Category
    var getData = DiagnosisService.GetCategory();
    getData.then(function (dt) {
        alert("passed");
        $scope.CategoryList = dt.data;
    }, function (error) {
        alert("error in obtaining CIDCODE category");

    });



    // Function For Populate CIDCODE  // This function we will call after select change country
    $scope.GetCode = function () {
        //Load cidCode

        DiagnosisService.GetCode($scope.category.CID_CategorID).then(function (d) {
            $scope.CodeList = d.data;
            $scope.StateTextToShow = "Select State";
        }, function (error) {
            alert('Error!');
        });
    }
    $scope.saveToBasket = function () {
        var DiseaseCID = new Object();
        DiseaseCID.DiseaseCode = $scope.CidCode.DiseaseCode;
        DiseaseCID.CIDCategory = $scope.category;
        CIDclassificationVW.push(DiseaseCID);

    }
    $scope.saveCIDCODE = function () {
        if ($scope.CIDclassificationBuffer.length > 0) {
            var getData = DiagnosisService.SaveCIDclassificationDB($scope.CIDclassificationBuffer);
            alert("passed22222222222222222")
            getData.then(function (msg) {
                alert('CIDCODE posted');
            }, function () {
                alert('CIDCODE posting problem');
            });
        }
    }
    $scope.deleteCIDCODE = function (element) {
        var deleteIndex = CIDclassificationVW.indexOf(element);
        CIDclassificationVW.splice(deleteIndex, 1);
        //  CIDclassificationDB.splice(deleteIndex, 1);
    }



})
app.factory('DiagnosisService', function ($http) {
    var fac = {};
    fac.GetCategory = function () {
        return $http.get("../Diagnosis/GetCidCodeCategories");
    }
    fac.GetCode = function (CID_CategorID) {

        return $http.get('../Diagnosis/GetCIDByCategory?category_id=' + CID_CategorID)
    }


    fac.SaveCIDclassificationDB = function (CIDclassification) {
        alert("callled calssification");
        var CIDclassificationData = JSON.stringify({ 'CIDclassification': CIDclassificationVW });
        var response = $http({
            method: "post",
            headers: {
                'Content-Type': "application/json; charset=utf-8"
            },

            url: "../Diagnosis/ClassifyDisease_CID",
            data: CIDclassificationData,
            dataType: "json",
        });
        //Refreshing the buffers
        CIDclassificationVW = [];
        CIDclassificationDB = [];
        return response;
    }
    return fac;
});
