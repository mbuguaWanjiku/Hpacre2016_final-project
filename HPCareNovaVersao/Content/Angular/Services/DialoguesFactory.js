/// <reference path="../ModalViewsContent/modalLymphocyte.html" />
/// <reference path="../ModalViewsContent/modalLymphocyte.html" />


app.factory('alert', function ($uibModal) {

    var fac = {};
    fac.show = function (action, event) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalContent.html',
            controller: function () {
                var vm = this;
                vm.action = action;
                vm.event = event;
            },
            controllerAs: 'vm'
        });
    }

    fac.warning = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalWarning.html',
            controller: function () {
                var vm = this;
                vm.message = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.success = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalSuccess.html',
            controller: function () {
                var vm = this;
                vm.success = message;
            },
            controllerAs: 'vm'
        });
    }

    //fac.visitManager = function () {

    //    return $uibModal.open({
    //        backdrop: 'static',
    //        //keyboard: false,
    //        templateUrl: 'VisitManager.html',
    //        controller: function () {
    //            var vm = this;
             

    //        },
    //        controllerAs: 'vm'
    //    });
    //}
    fac.showObservation = function (obs) {
     
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalObservation.html',
            controller: function () {
                var vm = this;
                vm.observation = obs

            },
            controllerAs: 'vm'
        });
    }
  


















    fac.med = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalMed.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.kft = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalKft.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.lft = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalLft.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.lymphocyte = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalLymphocyte.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.platelets = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalPlatelets.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.rbcIndices = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalRbcIndices.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.rbcs = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalRbcs.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.viral = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalViralLoad.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.wbcs = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalWbcs.html',
            controller: function () {
                var vm = this;
                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.graphs = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalControlGraph.html',
            controller: function () {
                var vm = this;

                vm.observations = message;
            },
            controllerAs: 'vm'
        });
    }

    fac.specificGraphs = function (message) {
        return $uibModal.open({
            templateUrl: '../Content/Angular/ModalViewsContent/modalSpecificControlGraph.html',
            controller: function () {
                var vm = this;
                vm.observations = message;

              

            },
            controllerAs: 'vm'
        });
    }

    return fac;
});
