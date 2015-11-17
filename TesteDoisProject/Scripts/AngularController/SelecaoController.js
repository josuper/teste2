
angular.module('MyApp')
.controller('SelecaoController', function ($scope, SelecaoService) {
   
    $scope.SelecaoLista = [];
    SelecaoService.Listar().then(function (d) {
        $scope.SelecaoLista = d.data;
        alert($scope.SelecaoLista);
    });
    $scope.Lista = function () {
        SelecaoService.Listar().then(function (d) {
            $scope.SelecaoLista = d.data;
        });
    };
    $scope.Lista();

    $scope.SelecaoModelo = {
        SelecaoID: '',
        Designacao: ''
    };

    $scope.Registar = function () {
        SelecaoService.Registar($scope.SelecaoModelo).then(function (d) {
            $scope.Lista();
            alert(d);
        });
    };

})
.factory('SelecaoService', function ($http) {
    var fac = {};
    fac.Listar = function () {
        return $http.get('/Selecao/Listar');
    }

    fac.Registar = function (data) {
        $http({
            url: '/Selecao/RegistarM',
            method: 'POST',
            data: JSON.stringify(data),
            headers: { 'content-type': 'application/json' }
            
        }).sucess(function (d) {
            //defer.resolve(d);
        }).error(function (e, err) {
            console.log(e);
            console.log(err);
        });
    }
    return fac;
});