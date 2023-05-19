(function(){
    "use strict";

function CloudPublicAccessController($q, $http, umbRequestHelper, localizationService, $scope, $route) {    
    let vm = this;
    const baseApiUrl = "backoffice/api/CloudPublicAccess/";
    vm.pageTitle = '';
    vm.data = {};
    vm.isRedirecting = false;
    
    vm.cloudButton = cloudButton;
        
    function init() {
        vm.loading = true;
        
        var redirection = $route.current.params.returnTo;
        
        if (redirection !== undefined){
            vm.isRedirecting = true;
            vm.redirectingTo = redirection;
            window.location.href = redirection;
        }

        let getTitle = localizationService.localize("treeHeaders_cloudPublicAccess", 'Cloud Public Access title').then(function (value) {
            vm.pageTitle = value;
            $scope.$emit("$changeTitle", value);
        });
        
        let getSettings = umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            vm.data = data;
            vm.loading = false;
        });

        $q.all([getTitle, getSettings]).then(function () {
            vm.loading = false;
        });
    }

    init();
    
    function cloudButton(){
        var cloudPortal = "https://s1.umbraco.io";
        window.open(cloudPortal, '_blank').focus();
    }
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudPublicAccessController);
})();