﻿angular.module("resource.comments", ["ngResource"])
.factory "Comment", ['$resource',($resource) ->
  $resource "#{config.apiHost}/odata/Comment:id/:action", {id:'@id',action:'@action'},
    recent:
      method: "GET"
      params:
        action:"recent"
    del:
      method: "POST"
      params:
        action:'delete'
    renew:
      method: "POST"
      params:
        action:'renew'
    remove:
      method: "POST"
      params:
        action:'Remove'
    recover:
      method: "POST"
      params:
        action:'Recover'
]