(function () {
    function CoreServerGuidesService($http) {

        function GetServerGuides(url) {
            return $http.get(url)
                .then(function (response) {
                    return response;
                })
                .catch(function (error) {

                });
        }

        function GetServerTypes(url) {
            return $http.get(url)
                .then(function (response) {
                    return response;
                })
                .catch(function (error) {

                });
        }

        function CreateServerGuides(url, data) {
            return $http.post(url, data).then(function (response) {
                return response;
            }).catch(function (error) {

            });
        }

        return {
            GetServerGuides: GetServerGuides,
            CreateServerGuides: CreateServerGuides,
            GetServerTypes: GetServerTypes
        };
    }


    angular.module('CoreTemplateApp').factory('coreServerGuidesService', CoreServerGuidesService);
    CoreServerGuidesService.$inject = ['$http'];
}());