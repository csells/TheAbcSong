﻿using System;
using Xamarin.Forms;

namespace TheAbcSong {
  public class App {
    public static Page GetMainPage() {
      return new MainPage();
    }
  }

  public class MainPage : ContentPage {
    public MainPage() {
      var resourcePath = this.GetType().Namespace + "." + Device.OnPlatform("iOS", "Droid", "WinPhone") + ".MVC-013F.JPG";
      var boysImage = new Image {
        Aspect = Aspect.AspectFill,
        Source = ImageSource.FromResource(resourcePath),
      };
      var johnButton = new Button { Text = "John", HorizontalOptions = LayoutOptions.Center };
      var tomButton = new Button { Text = "Tom", HorizontalOptions = LayoutOptions.Center };

      johnButton.Clicked += (sender, e) => PlayAudio("97-11-5-John-singing.mp3");
      tomButton.Clicked += (sender, e) => PlayAudio("99-01-15-Tom-Singing.mp3");

      Grid.SetColumnSpan(boysImage, 2);
      Grid.SetRow(johnButton, 1);
      Grid.SetColumn(johnButton, 0);
      Grid.SetRow(tomButton, 1);
      Grid.SetColumn(tomButton, 1);

      Content = new Grid {
        HorizontalOptions = LayoutOptions.FillAndExpand,
        VerticalOptions = LayoutOptions.FillAndExpand,
        Children = { boysImage, johnButton, tomButton },
        ColumnDefinitions = {
          new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
          new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
        },
        RowDefinitions = {
          new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
          new RowDefinition { Height = GridLength.Auto },
        },
      };
    }

    void PlayAudio(string name) {
      Device.OpenUri(new Uri("http://sellsbrothers.com/Content/poststuff/fun/" + name));
    }

  }
}

