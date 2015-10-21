module DGraph {
    "use strict";

    export class Search {
        private keywords: string;
        private name: string;
        private page: number;
        private totalPages: number;
        private context: JQuery;
        private $: JQueryStatic;

        constructor(context: JQuery, $: JQueryStatic) {
            this.keywords = "";
            this.name = "";
            this.context = context;
            this.$ = $;
            this.page = 1;
            this.totalPages = parseInt($("#TotalPages", $(this.context)).val());

            this.initialize();
        }

        getRequestData(that): string {
            var self = that;
            var requestData: string = $(self.context).serialize();
            return requestData;
        }

        initialize(): void {
            var self = this;
            $("#Keywords", this.context).val(self.keywords);
            $("#Name", this.context).val(self.name);

            $("#results").on('click', "#nextPage", () => self.nextPage(self));
            $("#results").on('click', "#prevPage", () => self.prevPage(self));
        }

        prevPage(self): void {
            debugger;
            self.page = parseInt($("#Page", $(self.context)).val());
            if (self.page < self.totalPages) {
                self.page--;
                $("#Page", $(self.context)).val(self.page);
                $(self.context).submit();
            }
        }

        nextPage(self): void {
            debugger;
            self.page = parseInt($("#Page", $(self.context)).val());
            if (self.page < self.totalPages) {
                self.page++;
                $("#Page", $(self.context)).val(self.page);
                $(self.context).submit();
            }
        }
    }
}