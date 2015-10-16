var DGraph;
(function (DGraph) {
    "use strict";
    var Search = (function () {
        function Search(context, $) {
            this.keywords = "jquery mvc";
            this.name = "jquery";
            this.context = context;
            this.$ = $;

            this.initialize();
        }
        Search.prototype.initialize = function () {
            $("#keywords", this.context).val(this.keywords);
            $("#name", this.context).val(this.name);

            $(this.context).on('submit', this.submitSearchForm);
        };

        Search.prototype.getRequestData = function () {
            var requestData = {
                keywords: $("#keywords", this.context).val(),
                name: $("#name", this.context).val()
            };

            return requestData;
        };

        Search.prototype.submitSearchForm = function () {
            var _this = this;
            $.ajax({
                url: "/Search/Search",
                data: function () {
                    return _this.getRequestData();
                },
                contentType: "application/json; charset=utf-8",
                dataType: "json",
                async: true,
                type: "GET",
                error: function (xhr, status, message) {
                    console.log("something bad happended: " + message);
                }
            }).done(function () {
                console.log("Done with the request");
            });

            return false;
        };
        return Search;
    })();
    DGraph.Search = Search;
})(DGraph || (DGraph = {}));
//# sourceMappingURL=search.js.map
