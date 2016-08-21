app.controller("RegularExamHistoryController", function ($scope, regularExamHistoryFactory,showResultModal) {


    $scope.showText = function (option) {
       alert(JSON.stringify(option))
        var mcdt = regularExamHistoryFactory.getSpecificMCDT(option.Mcdt_id);
        mcdt.then(function (dt) {
            showResultModal.Text(dt.data[0],option.Discriminator);
        }, function () {
            alert('Error in getting records');
        });
   
        };



    var getDatakft = regularExamHistoryFactory.regularExamHistory("KFT");
    getDatakft.then(function (mcdtHistory) {
        $scope.regularExamHistoryKFT = mcdtHistory.data;
        
    }, function () {
        alert('Error in getting records');
    });


    var getDataLft = regularExamHistoryFactory.regularExamHistory("LFT");
    getDataLft.then(function (mcdtHistory) {
        $scope.regularExamHistoryLFT = mcdtHistory.data;

    }, function () {
        alert('Error in getting records');
    });

    var getDataRbc = regularExamHistoryFactory.regularExamHistory("RBCS");
    getDataRbc.then(function (mcdtHistory) {
        $scope.regularExamHistoryRBCS = mcdtHistory.data;

    }, function () {
        alert('Error in getting records');
    });

    var getDataRbcs = regularExamHistoryFactory.regularExamHistory("RBCIndices");
    getDataRbcs.then(function (mcdtHistory) {
        $scope.regularExamHistoryRBCIndices = mcdtHistory.data;

    }, function () {
        alert('Error in getting records');
    });


    var getDataLymp = regularExamHistoryFactory.regularExamHistory("LymphocytesSubsets");
    getDataLymp.then(function (mcdtHistory) {
        $scope.regularExamHistoryLymphocytesSubsets = mcdtHistory.data;

    }, function () {
        alert('Error in getting records');
    });



     var getDataVL = regularExamHistoryFactory.regularExamHistory("ViralLoad");
    getDataVL.then(function (mcdtHistory) {
        $scope.regularExamHistoryViralLoad = mcdtHistory.data;

    }, function () {
        alert('Error in getting records');
    });




    var getDataPC = regularExamHistoryFactory.regularExamHistory("PlateletsCount");
    getDataPC.then(function (mcdtHistory) {
        $scope.regularExamHistoryPlateletsCount = mcdtHistory.data;

    }, function () {
        alert('Error in getting records');
    });


    var getDataWBCS = regularExamHistoryFactory.regularExamHistory("WBCS");
    getDataWBCS.then(function (mcdtHistory) {
        $scope.regularExamHistoryWBCS = mcdtHistory.data;

    }, function () {
        alert('Error in getting records');
    });



    $scope.rowLimit = 20;
    $scope.sortColumn = "MCDT_date";
});












