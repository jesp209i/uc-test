function CloudPublicAccessController($q, $http, umbRequestHelper, localizationService, $scope) {    
    var vm = this;
    var baseApiUrl = "backoffice/api/CloudPublicAccess/";
    vm.pageTitle = "";
    vm.data = {};
    function init() {
        vm.loading = true;

        var getTitle = localizationService.localize("treeHeaders_cloudPublicAccess", 'Cloud Public Access title').then(function (value) {
            console.log(value);
            vm.pageTitle = value;
            $scope.$emit("$changeTitle", value);
        }, function(error){
            console.log(error);
        });
        

        // Load all languages
        var getSettings = umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "GetSettings")
        ).then(function (data) {
            console.log(data);
            vm.data = data;
            vm.loading = false;
        }, function(error){
            console.log(error);
        });

        $q.all([getTitle, getSettings]).then(function () {
            vm.loading = false;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudPublicAccessController);