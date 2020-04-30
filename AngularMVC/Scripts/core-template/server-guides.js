var CoreTemplateApp = angular.module('CoreTemplateApp', ['angularUtils.directives.dirPagination']);



CoreTemplateApp.controller('serverguidesController', function ($scope, coreServerGuidesService) {
    $scope.GetServerGuides = function () {
        coreServerGuidesService.GetServerGuides('/CoreTemplate/GetServerGuides')
            .then(function (result) {
                $scope.serverguides = result.data.result;
                //$scope.serverguides.updateList = result.data.result;
        });
    };

    $scope.GetServerTypes = function () {
        coreServerGuidesService.GetServerTypes('/CoreTemplate/GetServerTypes')
            .then(function (result) {
                $scope.servertypes = result.data.result;
            });
    };

    
    $scope.CreateServerGuides = function () {
        $scope.frmCreateData = {};
        $scope.frmCreateData.ServerTypeId = $scope.frmCreateData.item.ServerTypeId;
        $scope.frmCreateData.ServerTypeName = $scope.frmCreateData.item.ServerTypeName;
        coreServerGuidesService.CreateServerGuides('/CoreTemplate/CreateServerGuides', $scope.frmCreateData)
            .then(function (result) {
                
                if (result.data.isSuccess) {
                    $scope.serverguides.unshift(result.data.dto);
                }
            });
    };

    
    $scope.UpdateServerGuides = function () {
        
        //$scope.frmUpdateData.ServerTypeId = $scope.frmUpdateData.item.ServerTypeId;
        //$scope.frmUpdateData.ServerTypeName = $scope.frmUpdateData.item.ServerTypeName;

        coreServerGuidesService.CreateServerGuides('/CoreTemplate/UpdateServerGuides', $scope.ModifyData)
            .then(function (result) {

                //if (result.data.isSuccess) {
                //    $scope.serverguides.unshift(result.data.dto);
                //}
            });
    };

    $scope.ModifyServerGuides = function (model) {
        debugger;
        $scope.ModifyData = model;
    };
});