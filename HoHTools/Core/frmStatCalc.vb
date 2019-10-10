Public Class frmStatCalc
    Private Stats As New UserStats

    Private Class UserStats
        Public Scale As New ScaleStats
        Public HealthMod As Double
        Public ManaMod As Double
        Public ArmorMod As Double
        Public ResistanceMod As Double
        Public HealthRegenMod As Double
        Public ManaRegenMod As Double

        Public AttackPower As Integer
        Public SkillPower As Integer
        Public AttackEffect As ArrayList
        Public SkillEffect As ArrayList

        Public Class ScaleStats
            Public Base As New BaseStats
            Public Class BaseStats
                Public Health As Double
                Public Mana As Double
                Public HealthRegen As Double
                Public ManaRegen As Double
                Public Armor As Double
                Public Resistance As Double
            End Class

            Public Level As New LevelStats
            Public Class LevelStats
                Public Health As Double
                Public Mana As Double
                Public HealthRegen As Double
                Public ManaRegen As Double
                Public Armor As Double
                Public Resistance As Double
            End Class

            Public Mods As New ModStats
            Public Class ModStats
                Public Health As Double
                Public Mana As Double
                Public HealthRegen As Double
                Public ManaRegen As Double
                Public Armor As Double
                Public Resistance As Double
            End Class
        End Class

        Public Sub Clear()
            AttackPower = 0
            SkillPower = 0
            AttackEffect = New ArrayList
            SkillEffect = New ArrayList
            ClearScale()
        End Sub

        Public Sub ClearScale()
            Scale.Base.Health = 0
            Scale.Base.Mana = 0
            Scale.Base.HealthRegen = 0
            Scale.Base.ManaRegen = 0
            Scale.Base.Armor = 0
            Scale.Base.Resistance = 0
        End Sub

        Public Sub Reset()
            Clear()
        End Sub
    End Class

    Private Sub UpdateDisplayValues()
        lblHP.Text = Stats.Scale.Base.Health + (Stats.Scale.Level.Health * (nudLv.Value - 1))
        lblHPRegen.Text = Stats.Scale.Base.HealthRegen + (Stats.Scale.Level.HealthRegen * (nudLv.Value - 1))
        lblMP.Text = Stats.Scale.Base.Mana + (Stats.Scale.Level.Mana * (nudLv.Value - 1))
        lblMPRegen.Text = Stats.Scale.Base.ManaRegen + (Stats.Scale.Level.ManaRegen * (nudLv.Value - 1))
        lblArmor.Text = Stats.Scale.Base.Armor + (Stats.Scale.Level.Armor * (nudLv.Value - 1))
        lblResistance.Text = Stats.Scale.Base.Resistance + (Stats.Scale.Level.Resistance * (nudLv.Value - 1))
    End Sub

    Private Sub cmbClass_SelectedIndexChanged(sender As System.Object, e As System.EventArgs) Handles cmbClass.SelectedIndexChanged
        Console.WriteLine("Text: " & cmbClass.Items(cmbClass.SelectedIndex))

        Select Case cmbClass.Items(cmbClass.SelectedIndex)
            Case "Paladin"
                Stats.Scale.Base.Health = 75
                Stats.Scale.Base.Mana = 50
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 0.4
                Stats.Scale.Base.Armor = 10
                Stats.Scale.Base.Resistance = 0
                Stats.Scale.Level.Health = 10
                Stats.Scale.Level.Mana = 6
                Stats.Scale.Level.HealthRegen = 0.025
                Stats.Scale.Level.ManaRegen = 0.05
                Stats.Scale.Level.Armor = 0.7
                Stats.Scale.Level.Resistance = 0.2

            Case "Priest"
                Stats.Scale.Base.Health = 30
                Stats.Scale.Base.Mana = 70
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 1.9
                Stats.Scale.Base.Armor = 0
                Stats.Scale.Base.Resistance = 3
                Stats.Scale.Level.Health = 5
                Stats.Scale.Level.Mana = 11
                Stats.Scale.Level.HealthRegen = 0.05
                Stats.Scale.Level.ManaRegen = 0.1
                Stats.Scale.Level.Armor = 0.2
                Stats.Scale.Level.Resistance = 0.5

            Case "Ranger"
                Stats.Scale.Base.Health = 50
                Stats.Scale.Base.Mana = 50
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 0.5
                Stats.Scale.Base.Armor = 0
                Stats.Scale.Base.Resistance = 0
                Stats.Scale.Level.Health = 6
                Stats.Scale.Level.Mana = 6
                Stats.Scale.Level.HealthRegen = 0.025
                Stats.Scale.Level.ManaRegen = 0.075
                Stats.Scale.Level.Armor = 0.5
                Stats.Scale.Level.Resistance = 0.2

            Case "Sorcerer"
                Stats.Scale.Base.Health = 40
                Stats.Scale.Base.Mana = 75
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 1.5
                Stats.Scale.Base.Armor = 0
                Stats.Scale.Base.Resistance = 2
                Stats.Scale.Level.Health = 5
                Stats.Scale.Level.Mana = 16
                Stats.Scale.Level.HealthRegen = 0.025
                Stats.Scale.Level.ManaRegen = 0.1
                Stats.Scale.Level.Armor = 0.2
                Stats.Scale.Level.Resistance = 0.5

            Case "Thief"
                Stats.Scale.Base.Health = 40
                Stats.Scale.Base.Mana = 40
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 0.5
                Stats.Scale.Base.Armor = 0
                Stats.Scale.Base.Resistance = 0
                Stats.Scale.Level.Health = 5
                Stats.Scale.Level.Mana = 8
                Stats.Scale.Level.HealthRegen = 0.025
                Stats.Scale.Level.ManaRegen = 0.1
                Stats.Scale.Level.Armor = 0.3
                Stats.Scale.Level.Resistance = 0.3

            Case "Warlock"
                Stats.Scale.Base.Health = 60
                Stats.Scale.Base.Mana = 75
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 1.5
                Stats.Scale.Base.Armor = 2
                Stats.Scale.Base.Resistance = 2
                Stats.Scale.Level.Health = 6
                Stats.Scale.Level.Mana = 13
                Stats.Scale.Level.HealthRegen = 0.025
                Stats.Scale.Level.ManaRegen = 0.075
                Stats.Scale.Level.Armor = 0.3
                Stats.Scale.Level.Resistance = 0.3

            Case "Wizard"
                Stats.Scale.Base.Health = 35
                Stats.Scale.Base.Mana = 75
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 1.5
                Stats.Scale.Base.Armor = 0
                Stats.Scale.Base.Resistance = 2
                Stats.Scale.Level.Health = 4
                Stats.Scale.Level.Mana = 15
                Stats.Scale.Level.HealthRegen = 0.025
                Stats.Scale.Level.ManaRegen = 0.1
                Stats.Scale.Level.Armor = 0.2
                Stats.Scale.Level.Resistance = 0.5

            Case "Gladiator"
                Stats.Scale.Base.Health = 65
                Stats.Scale.Base.Mana = 50
                Stats.Scale.Base.HealthRegen = 0
                Stats.Scale.Base.ManaRegen = 0.5
                Stats.Scale.Base.Armor = 2
                Stats.Scale.Base.Resistance = 0
                Stats.Scale.Level.Health = 7
                Stats.Scale.Level.Mana = 7
                Stats.Scale.Level.HealthRegen = 0.025
                Stats.Scale.Level.ManaRegen = 0.05
                Stats.Scale.Level.Armor = 0.3
                Stats.Scale.Level.Resistance = 0.3
        End Select

        UpdateDisplayValues()
    End Sub

    Private Sub nudLv_ValueChanged(sender As System.Object, e As System.EventArgs) Handles nudLv.ValueChanged
        UpdateDisplayValues()
    End Sub

End Class