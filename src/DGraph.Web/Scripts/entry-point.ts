﻿/// <reference path="typings/jquery/jquery.d.ts" />
/// <reference path="DGraph/search.ts" />

var search: DGraph.Search;

$(document).ready(() => {
    try {
        search = new DGraph.Search($("body"), jQuery);
    }
    catch (e) {
        //aaaa
    }
});