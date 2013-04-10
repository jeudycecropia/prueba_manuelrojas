### 
==========================================================
 apiConsumer.js v1.0.0
https://github.com/manuelrojas
 ==========================================================
 Author:Manuel Rojas
 Date:4/9/2013
==========================================================
 ###
((window, $, EMPTY)->
  class ApiConsumer
    
    #Bind Events
    init: () ->
      ApiConsumer.holder = $('.profile')
      ApiConsumer.loginControl = $('.login-control')
      $('button.btn#login').click @.logIn
    
    logIn: () =>
      
      user = $('#inputEmail').val()
      pass = $('#inputPassword').val()
      account = {user: user, password: pass}
      
      $.ajax
        url: '../api/login'
        type: "Post"
        dataType: "json"
        data: account
        error: (xhr, status, error) ->
          console.error error
        success:  (account) ->
          isValid = account.result
          $alertSuccess = $('.alert.alert-success')
          $alertError = $('.alert.alert-error')

          $alertSuccess.addClass('hide')
          $alertError.addClass('hide')

          if(isValid)
            $alertSuccess.removeClass('hide')
                         .addClass('in')
            ### Ajax call and build profile###
            ApiConsumer.handleProfile account.token            
          else
            $alertError.removeClass('hide')
                       .addClass('in')

      return false
      
    ApiConsumer.handleProfile = (token) ->
      #Ajax call
      $.ajax
        url: "../api/profile/#{token}"
        type: "GET"
        dataType: "json"
        error: (xhr, status, error) ->
          console.error error
        success: (profile) ->
          ApiConsumer.buildProfile profile

    ApiConsumer.buildProfile = (profile) ->
      console.log profile
      ### Profile Template ###
      profileMarkUp = """
          <div class="span3">
            <strong>Name</strong> #{profile.Name} <br>
            <strong>Last Name</strong> #{profile.LastName} <br>
             <strong>Email</strong> #{profile.Email} <br>
            <strong>Phone</strong> #{profile.Phone} <br>
            <address>
            <strong>#{profile.Address}</strong><br>
            795 Folsom Ave, Suite 600<br>
            San Francisco, CA 94107<br>
            <abbr title="Phone">P:</abbr> (123) 456-7890
            </address>
          </div>
          """
      ApiConsumer.holder.addClass 'in'
      ApiConsumer.holder.append profileMarkUp
      #Hide Login-Control
      ApiConsumer.loginControl.addClass 'hide'
      

  ### Create Api Consumer ###
  $(document).ready(()->
    apiConsumer = new ApiConsumer()
    apiConsumer.init()
  )

)(window, jQuery)