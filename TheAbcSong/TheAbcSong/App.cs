using Xamarin.Forms;

namespace TheAbcSong {
  public class App : Application {
    public App() {
      var boysImage = new Image {
        Aspect = Aspect.AspectFit,
        Source = ImageSource.FromResource(
          this.GetType().Namespace + "." + Device.OnPlatform("iOS", "Droid", "WinPhone") + ".MVC-013F.JPG"),
      };
      var johnButton = new Button { Text = "John", HorizontalOptions = LayoutOptions.Center };
      var tomButton = new Button { Text = "Tom", HorizontalOptions = LayoutOptions.Center };

      johnButton.Clicked += (sender, e) => PlayAudio("97-11-5 John singing.wav");
      tomButton.Clicked += (sender, e) => PlayAudio("99-01-15 Tom Singing.wav");

      Grid.SetColumnSpan(boysImage, 2);
      Grid.SetRow(johnButton, 1);
      Grid.SetColumn(johnButton, 0);
      Grid.SetRow(tomButton, 1);
      Grid.SetColumn(tomButton, 1);

      MainPage = new ContentPage {
        Content = new Grid {
          VerticalOptions = LayoutOptions.Center,
          Children = { boysImage, johnButton, tomButton },
          ColumnDefinitions = {
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
            new ColumnDefinition { Width = new GridLength(1, GridUnitType.Star) },
          },
          RowDefinitions = {
            new RowDefinition { Height = new GridLength(1, GridUnitType.Star) },
            new RowDefinition { Height = GridLength.Auto },
          },
        },
      };
    }

    void PlayAudio(string name) {
    }

  }
}
