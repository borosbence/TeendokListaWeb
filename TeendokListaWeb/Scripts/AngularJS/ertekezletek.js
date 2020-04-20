var app = angular.module("ertekezletek", []);

app.controller('tabledata', function ($scope, $http) {
    $scope.ertekezletekArr = []; // Üres tömb létrehozása
    $scope.ujErtekezlet = {};
    // Adatok lekérdezése
    $http.get("/api/Ertekezletek")
        .then(function (response) {
            // Tömbök feltöltése
            $scope.ertekezletekArr = response.data;
            console.log($scope.ertekezletekArr);
        })
        .catch(function (response) {
            $scope.error = response.statusText;
        });

    // Sorbarendezés
    $scope.sort = function (keyname) {
        if (keyname === $scope.sortKey) {
            $scope.reverse = !$scope.reverse;
        }
        $scope.sortKey = keyname;
    }

    // Létrehozás
    $scope.post = function (ertekezlet) {
        $scope.ujErtekezlet = null;
        $http.post("api/Ertekezletek", JSON.stringify(ertekezlet))
            .then(function () {
                $scope.ertekezletekArr.push(ertekezlet);
                $scope.ujErtekezlet = null;
            })
            .catch(function (response) {
                $scope.error = response.statusText;
            });
    }

    // Törlés
    $scope.delete = function (ertekezlet) {
        $http.delete("/api/Ertekezletek" + "/" + ertekezlet.id)
            .then(function () {
                var index = $scope.ertekezletekArr.indexOf(ertekezlet);
                $scope.ertekezletekArr.splice(index, 1); 
        });
    }
});