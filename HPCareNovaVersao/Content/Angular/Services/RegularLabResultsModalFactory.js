/// <reference path="../../LabResults/ModalsContents/KFTContent.html" />


app.factory('showResultModal', function ($uibModal) {
    function createTemplate(mcdtObject, type) {
        var header = function () {
            var divHeader = document.createElement("div");
            divHeader.className = 'modal-header';
            var h3 = document.createElement("h3");
            h3.classList.add('modal-title');
            h3.appendChild(document.createTextNode(type + '  Results'));
            divHeader.appendChild(h3);
            return divHeader;
        }      
        var body = function () {
            var bodyDiv = document.createElement("div");
            bodyDiv.className = 'modal-body';
            var h1, span, label;
            for (var prop in mcdtObject) {
                if (!mcdtObject.hasOwnProperty(prop)) {
                    //The current property is not a indirect property of p
                    continue;
                }
                span = document.createElement('span');
                label = document.createElement('label');
                label.appendChild(document.createTextNode(prop))
                h1 = document.createElement('h2').appendChild(document.createTextNode(mcdtObject[prop]));
                p = document.createElement('p');
                p.appendChild(label); p.appendChild(span); p.appendChild(h1);
                bodyDiv.appendChild(p)
            }
            return bodyDiv;
        }

        var footer = function () {
            var divFooter = document.createElement("div");
            divFooter.className = 'modal-footer';
            var btn = document.createElement('input');
            btn.type = 'button';
            btn.value = 'OK';
            btn.classList.add('btn'); btn.classList.add('btn-primary');
            btn.setAttribute('ng-click', '$close()');
            divFooter.appendChild(btn);
            return divFooter;
        }
        var mainDiv = document.createElement('div');
        mainDiv.appendChild(header());
        mainDiv.appendChild(body());
        mainDiv.appendChild(footer());
        return mainDiv;
    }

    var fac = {};
    fac.Text = function (result, type) {
        var temp = createTemplate(result, type).innerHTML;;
        return $uibModal.open({
            //templateUrl: '../Content/Templates/RegularLabResults/KFTContent.html',
            template: temp,
            controller: function () {
                var vm = this;
                vm.result = result;

            },
            controllerAs: 'vm'
        });
    }

    return fac;
});
