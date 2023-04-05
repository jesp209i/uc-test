(function(){
    "use strict";

function CloudPublicAccessController($q, $http, umbRequestHelper, localizationService, $scope) {    
    let vm = this;
    const baseApiUrl = "backoffice/api/CloudPublicAccess/";
    vm.pageTitle = '';
    vm.data = {};
    function init() {
        vm.loading = true;

        let getTitle = localizationService.localize("treeHeaders_cloudPublicAccess", 'Cloud Public Access title').then(function (value) {
            console.log(value);
            vm.pageTitle = value;
            $scope.$emit("$changeTitle", value);
        });
        
        let getSettings = umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            console.log(data);
            vm.data = data;
            vm.loading = false;
        });

        $q.all([getTitle, getSettings]).then(function () {
            vm.loading = false;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudPublicAccessController);
})();