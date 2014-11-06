'use strict';
app.factory('booksService', ['$http', 'ngAuthSettings', function ($http, ngAuthSettings) {
	
	var serviceBase = ngAuthSettings.apiServiceBaseUri;
	var booksServiceFactory = {};

	var _getBooks = function () {
		return $http.get(serviceBase + 'api/books').then(function (results) {
			return results;
		});
	};

	var _create = function (book) {
		return $http.post(serviceBase + 'api/books', book).success(function (data, status, headers) {
			//alert("cretated");
			return data;
		});
	};

	booksServiceFactory.getBooks = _getBooks;
	booksServiceFactory.create = _create;
	return booksServiceFactory;
}]);