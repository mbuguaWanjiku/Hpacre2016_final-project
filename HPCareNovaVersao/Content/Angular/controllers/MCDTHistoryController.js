app.controller("RegularExamHistoryController", function ($scope,$filter, regularExamHistoryFactory,showResultModal) {


    $scope.showText = function (option) {
       alert(JSON.stringify(option))
        var mcdt = regularExamHistoryFactory.getSpecificMCDT(option.Mcdt_id);
        mcdt.then(function (dt) {
            showResultModal.Text(dt.data[0],option.Discriminator);
        }, function () {
            alert('Error in getting records');
        });
   
        };
    $scope.rowLimit = 20;
    $scope.sortColumn = "MCDT_date";
    $scope.showGraph = function(size,sortOrder){
        alert(size + sortOrder);
   
        var arraySorted = $filter('orderBy')($scope.regularExamHistoryKFT, sortOrder);
        var arrayIds = [];

        for (var i = 0; i < arraySorted.length; i++) {
            arrayIds.push(arraySorted[i].Mcdt_id);
        }
        alert(JSON.stringify(arrayIds));
       
   }
    

/****************************************************************************************************************/


var columnsNames = null;

var startDate = null;
var endDate = null;
var todayDate = new Date();

function StatisticsObject(label, fillColor, strokeColor, pointColor, pointStrokeColor, data) {
    this.label = label;
    this.fillColor = fillColor || "rgba(51, 51, 51, 0)";
    this.strokeColor = strokeColor;
    this.pointColor = pointColor;
    this.pointStrokeColor = pointStrokeColor || "#fff";;
    this.data = data;
}
StatisticsObject.prototype.constructor = Object.create(StatisticsObject.prototype);

function Labels(dates) {
    this.dates = [];
}
Labels.prototype.constructor = Object.create(Labels.prototype);

var lineChartData = {
    labels: [],
    datasets: []
};



function getRandomColor() {
    var letters = '0123456789ABCDEF';
    var color = '#';
    for (var i = 0; i < 6; i++) {
        color += letters[Math.floor(Math.random() * 16)];
    }
    return color;
}

//*********************************************************//

//app.controller("GraphsController", function ($scope, GraphsFactory, $interval) {

    //document.getElementById("date-start").value = '2016/01/01';
    //document.getElementById("date-end").value = todayDate.getFullYear() + "/" + (todayDate.getMonth() + 1) + "/" + todayDate.getDay();

    function drawGraphs() {
        //startDate = document.getElementById("date-start").value;
        //endDate = document.getElementById("date-end").value;
       
        var getLabels = GraphsFactory.GetDates(selectedDescription);
        getLabels.then(function (dt) {
            $scope.dates = dt.data;//data de cada mcdt_date todos KFTS
            var temp = [];
            for (var i = 0; i < dt.data.length; i++) {
                var value = new Date(parseInt(dt.data[i].substr(6)));
                var ret = value.getDate() + "/" + (value.getMonth() + 1) + "/" + value.getFullYear();
                temp.push(ret);
            }
            for (var i = 0; i < temp.length; i++) {
                lineChartData.labels.push(temp[i]);
            }

        }, function (error) {
            alert("error");
        });

        var getColumnsNames = GraphsFactory.GetColumns(selectedDescription);
        getColumnsNames.then(function (data) {

            var getData = GraphsFactory.GetValues(selectedDescription);
            getData.then(function (dt) {
                //dt = todo kfts
                var columnsNumber = (dt.data.length - 1) / (dt.data[dt.data.length - 1]); //numero de colunas 
                var rowsNumber = dt.data[dt.data.length - 1]; //numero de rows
                var rest = 0;
                var temp = [];
                while (rest < columnsNumber) {
                    for (var i = 0; i < dt.data.length - 1; i++) {
                        if ((i % columnsNumber == rest)) {
                            temp.push(dt.data[i]);
                        }
                    }

                    var color = getRandomColor();
                    var insert = new StatisticsObject(data.data[rest], "rgba(51, 51, 51, 0)", color, color, "#fff", temp);
                    lineChartData.datasets.push(insert);
                    rest++;
                    i = 0;
                    temp = [];
                }
                new Chart(document.getElementById("line").getContext("2d")).Line(lineChartData);

            }, function (error) {
                alert("error");
            });

        });

    }

    //function Tipo(description) {
    //    this.description = description;
    //}
    //Tipo.prototype.constructor = Object.create(Tipo.prototype);

    //$scope.mcdtList = [];

    //$scope.mcdtList.push(new Tipo('KFT'));
    //$scope.mcdtList.push(new Tipo('LFT'));
    //$scope.mcdtList.push(new Tipo('LymphocytesSubsets'));
    //$scope.mcdtList.push(new Tipo('PlateletsCount'));
    //$scope.mcdtList.push(new Tipo('RBCIndices'));
    //$scope.mcdtList.push(new Tipo('RBCs'));
    //$scope.mcdtList.push(new Tipo('ViralLoad'));
    //$scope.mcdtList.push(new Tipo('WBCS'));

    $scope.LabExams = null;

    $scope.clickedElement = function () {
        selectedDescription = $scope.LabExams.description;

        lineChartData.labels = [];
        lineChartData.datasets = [];
        drawGraphs();
    }

//});

//*********************************************************//

























































































































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



  
});












