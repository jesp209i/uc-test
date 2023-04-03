// Umbraco.Cloud.PublicAcccessController
function CloudSecretsController($http, umbRequestHelper) {
    let vm = this;
    let baseApiUrl = "backoffice/UmbracoCloudSecrets/CloudSecrets/";

    function init() {
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "SecretKeys")
        ).then(function (data) {
            vm.data = data;
        });
        umbRequestHelper.resourcePromise(
            $http.get(baseApiUrl + "KeyVaultName")
        ).then(function (keyVaultName) {
            vm.keyVaultName = keyVaultName;
        });
    }

    init();
}

angular.module("umbraco").controller("Umbraco.Cloud.PublicAccessController", CloudSecretsController);