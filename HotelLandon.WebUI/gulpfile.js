'use strict'
var gulp = require("gulp");
var sass = require("gulp-sass");
var rename = require("gulp-rename");
var csso = require("gulp-csso");

gulp.task("sass", function () {
    return gulp.src("wwwroot/scss/site.scss")
        .pipe(sass())
        .pipe(gulp.dest("wwwroot/css/"));
});
gulp.task("minify-css", function () {
    return gulp.src(["wwwroot/css/*.css", "!wwwroot/css/*.min.css"])
        .pipe(rename({ extname: "min.css" }))
        .pipe(csso())
        .pipe(gulp.dest("wwwroot/css"));
});
exports.default = gulp.series(["sass", "minify-css"]);
