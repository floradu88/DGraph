/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="DGraph/search.ts" />
var search;
$(document).ready(function () {
    try {
        search = new DGraph.Search($("body"), jQuery);
    }
    catch (e) {
    }
});
//# sourceMappingURL=entry-point.js.map