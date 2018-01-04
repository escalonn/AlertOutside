node('master'){
    stage('import'){
        try{
            git url: 'https://github.com/sofani/AlertOutside.git'
        } catch(error) {
            slackSend message:{env.BUILD_NUMBER} color:'danger'
        }
    }

    stage('build'){
        try{

        } catch(error) {
                slackSend message: color:'danger'
            }
        }

    stage('analyze'){
        try{

        }   catch(error) {
                slackSend message: color:'danger'
            }
        }

    stage('test'){
        try{

        }   catch(error) {
                slackSend message: color:'danger'
            }
        }

    stage('package'){
        try{

        }   catch(error) {
                slackSend message: color:'danger'
            }
        }

    stage('deploy'){
        try{

        }   catch(error) {
                slackSend message: color:'danger'
            }
        }

}