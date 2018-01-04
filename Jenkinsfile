node('master'){
    stage('import'){
        try{
            git url: 'https://github.com/sofani/AlertOutside.git'
        } catch {
            slackSend message:{env.BUILD_NUMBER} color:'danger'
        }
    }

    stage('build'){
        try{

        } catch {
                slackSend message: color:'danger'
            }
        }

    stage('analyze'){
        try{

        }   catch {
                slackSend message: color:'danger'
            }
        }

    stage('test'){
        try{

        }   catch {
                slackSend message: color:'danger'
            }
        }

    stage('package'){
        try{

        }   catch {
                slackSend message: color:'danger'
            }
        }

    stage('deploy'){
        try{

        }   catch {
                slackSend message: color:'danger'
            }
        }

}