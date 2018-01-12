node('master') {
	stage('import') {
		try {
			git 'https://github.com/escalonn/AlertOutside.git'
		}
		catch (exc) {
			slackError('import')
			throw exc
		}
	}
	stage('build') {
		try {
			dir('LocationAlert') {
				bat 'dotnet build --no-incremental'
			}
		}
		catch (exc) {
			slackError('build')
			throw exc
		}
	}
	stage('analyze') {
		try {
			dir('LocationAlert') {
				bat 'SonarQube.Scanner.MSBuild begin /k:ao473840 /n:alertoutside /v:0.1.0'
				bat 'dotnet build --no-incremental'
				bat 'SonarQube.Scanner.MSBuild end'
			}
		}
		catch (exc) {
			slackError('analyze')
			throw exc
		}
	}
	stage('test') {
		try {
			dir('LocationAlert/LocationAlert.Test') {
				bat 'dotnet test'
			}
		}
		catch (exc) {
			slackError('test')
			throw exc
		}
	}
	stage('package') {
		try {
			dir('LocationAlert/LocationAlert.Client') {
				bat 'dotnet publish --output ../../Package'
			}
		}
		catch (exc) {
			slackError('package')
			throw exc
		}
	}
	stage('deploy') {
		try {
			bat "msdeploy -verb:sync -source:iisApp=\"C:\\Program Files (x86)\\Jenkins\\workspace\\LocationAlert\\Package\" -dest:iisApp=\"Default Web Site/LocationAlert\",computername=\"${env.MSDEPLOY_COMPUTERNAME}\",username=\"${env.MSDEPLOY_USERNAME}\",password=\"${env.MSDEPLOY_PASSWORD}\",authtype=basic -allowUntrusted -enableRule:AppOffline"
		}
		catch (exc) {
			slackError('deploy')
			throw exc
		}
	}
}

def slackError(stageName) {
	slackSend color: 'danger', message: "${stageName} stage failed. [<${JOB_URL}|${env.JOB_NAME}> <${env.BUILD_URL}console|${env.BUILD_DISPLAY_NAME}>] [${currentBuild.durationString[0..-14]}]"
}
