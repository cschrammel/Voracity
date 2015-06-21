var gulp = require('gulp');
var exec = require('child_process').exec;

gulp.task('watch', function () {
   gulp.watch('*.*', ['test']);
});
 
gulp.task('test', function(cb) {

    exec('cd /Users/carlschrammel/Documents/gittest/master/VoracityMac');
    
    exec('/Users/carlschrammel/.dnx/runtimes/dnx-mono.1.0.0-beta4/bin/dnx . test', function (err, stdout, stderr) {
      console.log(stdout);
      console.log(stderr);
      cb(err);
    });

});