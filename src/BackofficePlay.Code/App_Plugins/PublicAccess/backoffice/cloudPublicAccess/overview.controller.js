function CloudPublicAccessController($q, $http, umbRequestHelper, localizationService, $scope) {    
    vm = this;
    let baseApiUrl = "backoffice/api/CloudPublicAccess/";
    vm.loading = true;
    vm.pageTitle = 'Cloud Public Access';
    //vm.data = {};
    function init() {
        localizationService.localize("treeHeaders_cloudPublicAccess").then(function (value) {
            vm.pageTitle = value;
            $scope.$emit("$changeTitle", value);
        });
        
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            vm.data = data;
            vm.loading = false;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudPublicAccessController);